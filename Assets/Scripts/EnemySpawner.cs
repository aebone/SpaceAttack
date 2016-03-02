using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject Enemy; // Enemy prefab reference 
	public float maxSpawnRateInSeconds = 6f;

	// Use this for initialization
	void Start () {
		// Invoke the method to spawn the first enemy in 3 seconds
		Invoke ("SpawnEnemy", 3f);

		// Increase spawn rate every 30seconds
		InvokeRepeating("IncreaseSpawnRate", 0f, 30f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Spawn the enemy (method called once each 1 to maxSpawnRateInSeconds seconds)
	void SpawnEnemy (){
		// Find the screen limits to the player's movement based on the Camera
		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2 (0,0)); //bottom-left point (min.x, min.y)
		Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2 (1,1)); //top-right point (max.x, max.y)

		// Instantiate the Enemy prefab
		GameObject eachEnemy = (GameObject)Instantiate(Enemy);

		// Random position x of entrance, based on min and max Camera limit
		eachEnemy.transform.position = new Vector2 (Random.Range(min.x, max.x), max.y);

		// Schedule when to spawn next enemy
		ScheduleNextEnemySpawn();
	}

	void ScheduleNextEnemySpawn(){
		
		// Variable receiveas a random number between 1 and maxSpawnRateInSeconds
		float spawnInNSeconds = Random.Range (1f, maxSpawnRateInSeconds);

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
}
