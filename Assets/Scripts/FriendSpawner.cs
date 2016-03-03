using UnityEngine;
using System.Collections;

public class FriendSpawner : MonoBehaviour {

	public GameObject Friend; // Reference to the Friend prefab
	float maxSpawnRateInSeconds = 12f;
		

	void SpawnFriend() {
		// Check screen limit based on the camera. Max to start, min to destroy.
		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2 (0,0));
		Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2 (1, 1));

		GameObject friend = (GameObject)Instantiate (Friend);

		// Random position x of entrance, based on the x Camera limit
		friend.transform.position = new Vector2 (Random.Range(min.x, max.x), max.y);

		// Schedule when to spawn next friend
		ScheduleNextFriendSpawn();
	}

	void ScheduleNextFriendSpawn(){
		// Variable to receive a random number between 1 and maxSpawnRateInSeconds
		float spawnInNSeconds;

		// Check if maxSpawnRateInSeconds is above 0 to generate a ramdom number, if not set it to 1
		if (maxSpawnRateInSeconds > 2f) {
			// Generate random number 
			spawnInNSeconds = Random.Range (2f, maxSpawnRateInSeconds);
		} else {
			spawnInNSeconds = 2f;
		}

		// Invoke SpawnFriend() in spawnInNSeconds seconds
		Invoke ("SpawnFriend", spawnInNSeconds);
	}

	// Function to increase dificulty
	void IncreaseSpawnRate () {
		// Reduce in 1 second the interval of spawning each 30 seconds
		if (maxSpawnRateInSeconds > 2f) {
			maxSpawnRateInSeconds--;
		}

		if (maxSpawnRateInSeconds == 2f) {
			CancelInvoke ("IncreaseSpawnRate");
		}
	}
		
	/* 
	 * PUBLIC functions
	 * */

	// When Play Button is clicked
	public void ScheduleFriendSpawner() {
		// Reset the maxSpawnRateInSeconds
		maxSpawnRateInSeconds = 12f;

		// Invoke the first friend in 5 seconds
		Invoke("SpawnFriend", 6f);

		// Increase spawn rate every 30 seconds to turn it more difficult
		InvokeRepeating("IncreaseSpawnRate", 0f, 60f);
	}

	// Function to stop friend spawner
	public void UnscheduleFriendSpawner(){
		CancelInvoke("SpawnFriend");
		CancelInvoke("IncreaseSpawnRate");
	}
}