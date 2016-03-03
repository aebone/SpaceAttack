using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject Enemy; // Enemy prefab reference 
	float maxSpawnRateInSeconds = 6f;


	// Spawn the enemy (method called once each 1 to maxSpawnRateInSeconds seconds)
	void SpawnEnemy (){
		// Find the screen limits to the player's movement based on the Camera
		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2 (0,0)); //bottom-left point (min.x, min.y)
		Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2 (1,1)); //top-right point (max.x, max.y)

		// Instantiate the Enemy prefab
		GameObject enemy = (GameObject)Instantiate(Enemy);

		// Random position x of entrance, based on min and max Camera limit
		enemy.transform.position = new Vector2 (Random.Range(min.x, max.x), max.y);

		// Schedule when to spawn next enemy
		ScheduleNextEnemySpawn();
	}

	// RANDOM NUMBER
	void ScheduleNextEnemySpawn(){
		// Variable to receive a random number between 1 and maxSpawnRateInSeconds
		float spawnInNSeconds;

		// Check if maxSpawnRateInSeconds is above 0 to generate a ramdom number, if not set it to 1
		if (maxSpawnRateInSeconds > 1f) {
			// Generate random number 
			spawnInNSeconds = Random.Range (1f, maxSpawnRateInSeconds);
		} else {
			spawnInNSeconds = 1f;
		}

		// Invoke SpawnEnemy() in spawnInNSeconds seconds
		Invoke ("SpawnEnemy", spawnInNSeconds);
	}

	// Function to increase dificulty
	void IncreaseSpawnRate (){
		// Reduce in 1 second the interval of spawning each 30 seconds
		if (maxSpawnRateInSeconds > 1f) {
			maxSpawnRateInSeconds--;
		}

		if (maxSpawnRateInSeconds == 1f) {
			CancelInvoke ("IncreaseSpawnRate");
		}
	}

	/*
	 * PUBLIC functions
	 * */

	// User pressed play button - Function to start enemy spawner, called when game state is playing
	public void ScheduleEnemySpawner() {
		// Reset max spawn rate when user clicks play
		maxSpawnRateInSeconds = 6f;

		// Invoke the method to spawn the first enemy in 3 seconds
		Invoke ("SpawnEnemy", 3f);

		// Increase spawn rate every 30 seconds to turn it more difficult
		InvokeRepeating("IncreaseSpawnRate", 0f, 30f);
	}

	// Function to stop enemy spawner
		public void UnscheduleEnemySpawner(){
		CancelInvoke("SpawnEnemy");
		CancelInvoke("IncreaseSpawnRate");
	}
}
