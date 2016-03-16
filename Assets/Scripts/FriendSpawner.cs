using UnityEngine;
using System.Collections;

public class FriendSpawner : MonoBehaviour {

	public GameObject Friend; // Reference to the Friend prefab
	float maxSpawnRateInSeconds = 16f;
	float minSpawnRateInSeconds = 8f;	

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
		spawnInNSeconds = Random.Range (minSpawnRateInSeconds, maxSpawnRateInSeconds);

		// Invoke SpawnFriend() in spawnInNSeconds seconds
		Invoke ("SpawnFriend", spawnInNSeconds);
	}

	void DecreaseSpawnRate () {
		maxSpawnRateInSeconds++;
		minSpawnRateInSeconds++;	
	}
		
	/* 
	 * PUBLIC functions
	 * */

	// When Play Button is clicked
	public void ScheduleFriendSpawner() {
		// Reset the maxSpawnRateInSeconds
		maxSpawnRateInSeconds = 16f;
		minSpawnRateInSeconds = 8f;	

		// Invoke the first friend in 6 seconds
		Invoke("SpawnFriend", 6f);

		// Decrease spawn rate every 30 seconds
		InvokeRepeating("DecreaseSpawnRate", 0f, 30f);
	}

	// Function to stop friend spawner
	public void UnscheduleFriendSpawner(){
		CancelInvoke("SpawnFriend");
		CancelInvoke("DecreaseSpawnRate");
	}
}