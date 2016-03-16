using UnityEngine;
using System.Collections;

public class FriendGun : MonoBehaviour {

	public GameObject FriendBullet;

	// Use this for initialization
	void Start () {
		// Shoot the player 1 second after appears
		Invoke ("FireFriend", 1f);
	}

	// Update is called once per frame
	void Update () {

	}

	void FireFriend() {
		// Get a reference to the player's ship
		// Used to shoot on the player's direction
		GameObject Player = GameObject.Find("Player");

		if (Player != null) { // If the player is alive, shoot
			// Instantiate the enemy bullet
			GameObject bullet = (GameObject)Instantiate (FriendBullet);

			// Set the bullet instantiated initial position
			bullet.transform.position = transform.position;

			// Compute the direction to send it to the FriendBullet class
			Vector2 direction = Player.transform.position - bullet.transform.position;

			// Send the direction
			bullet.GetComponent<FriendBullet>().SetDirection(direction);
		}
	}
}
