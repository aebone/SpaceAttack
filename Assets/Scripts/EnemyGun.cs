using UnityEngine;
using System.Collections;

public class EnemyGun : MonoBehaviour {

	public GameObject EnemyBullet;

	// Use this for initialization
	void Start () {
		// Shoot the player 1 second after appears
		Invoke ("FireEnemy", 1f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FireEnemy() {
		// Get a reference to the player's ship
		// Used to shoot on the player's direction
		GameObject Player = GameObject.Find("Player");

		if (Player != null) { // If the player is alive, shoot
			// Instantiate the enemy bullet
			GameObject bullet = (GameObject)Instantiate (EnemyBullet);

			// Set the bullet instantiated initial position
			bullet.transform.position = transform.position;

			// Compute the direction to send it to the EnemyBullet class
			Vector2 direction = Player.transform.position - bullet.transform.position;

			// Send the direction
			bullet.GetComponent<EnemyBullet>().SetDirection(direction);
		}
	}
}
