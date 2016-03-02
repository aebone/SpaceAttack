using UnityEngine;
using System.Collections;

public class EnemyBullet : MonoBehaviour {

	public float speed = 3f; // Speed of the bullet

	Vector2 direction; // Get the bullet direction reference 
	bool isReady = false; // Helper to know when the bullet direction is set
	
	// Update is called once per frame
	void Update () {
		if (isReady == true) {
			// Get the bullet current position
			Vector2 position = transform.position;

			// Compute the bullet position
			position = position + this.direction * speed * Time.deltaTime;

			// Update the new position (shoot)
			transform.position = position;
		}
	}

	// Function to set the bullet's direction
	// public because it will receive the direction from the EnemyGun class
	public void SetDirection(Vector2 direction) {
		// Set the .normalized to get only a unit vector
		this.direction = direction.normalized;
		isReady = true;
	}
}
