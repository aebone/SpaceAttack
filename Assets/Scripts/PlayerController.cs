using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 3.5f;
	public GameObject GameManager; // Refrence to the GameManager
	public GameObject PlayerBullet; // Reference to the PlayerBullet prefab
	public GameObject GunPosition; // Reference to the empty PlayerGun object (starting bullet point)
	public GameObject Explosion; // Reference to the explosion prefab
	public GameObject GreenExplosion; // Reference to the explosion prefab
	public Text LivesTextUI; // Lives text
	int maxLives = 3; // Number of lives when start
	int lives; // To count lives


	// Update is called once per frame
	void Update () {

		// Fire bullets when the z is pressed
		if (Input.GetKeyDown("z")){
			// Play shoot sound
			gameObject.GetComponent<AudioSource>().Play();

			// Instantiate the bullet
			GameObject bullet = (GameObject)Instantiate(PlayerBullet);
			bullet.transform.position = GunPosition.transform.position; // Set the bullet initial position
		}

		// Set the inputs for movement - Arrows or AWDS
		float x = Input.GetAxisRaw ("Horizontal");
		float y = Input.GetAxisRaw ("Vertical");

		// Call the function to move the player
		Move (x, y);
	}

	void Move(float x, float y) {
		// Find the screen limits to the player's movement based on the Camera
		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2 (0,0)); //bottom-left point (min.x, min.y)
		Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2 (1,1)); //top-right point (max.x, max.y)

		// Add and sub minimum and maximum edges to fit the player on the camera
		// It is the half of the sprite pixels value, 29 x 64, since the pivot is on center
		min.x = min.x + 0.145f; 
		min.y = min.y + 0.32f; 
		max.x = max.x - 0.145f;
		max.y = max.y - 0.32f; 

		// Get the players current position
		Vector2 position = transform.position;

		// Add movement from the current position
		position = new Vector2 
			(transform.position.x + (x * speed * Time.deltaTime),
			 transform.position.y + (y * speed * Time.deltaTime));

		// Make sure the new position is not outside the screen
		// Clamp method hold the object based on the passed values
		position.x = Mathf.Clamp(position.x, min.x, max.x);
		position.y = Mathf.Clamp(position.y, min.y, max.y);

		// Update the players position after position variable is checked
		transform.position = position;
	}

	// Check if the object collides with other objects
	void OnTriggerEnter2D (Collider2D collider) {
		// If the player collides with the Enemy ship or the Enemy bullet, destroy it
		if (collider.tag == "EnemyTag" || collider.tag == "EnemyBulletTag" || collider.tag == "FriendTag") {
			PlayExplosionAnimation ();
			lives--;
			LivesTextUI.text = lives.ToString ();
			// If player is dead
			if (lives == 0) {
				// Change GameState to GameOver
				GameManager.GetComponent<GameManager>().SetGameState(global::GameManager.GameManagerState.GameOver);
				// Disable the player
				gameObject.SetActive(false);
			}
		}
		if (collider.tag == "FriendBulletTag") {
			PlayGreenExplosionAnimation ();
			lives++;
			LivesTextUI.text = lives.ToString ();
		}
	}

	void PlayExplosionAnimation(){
		// Instantiate the explosion
		GameObject explosion = (GameObject)Instantiate(Explosion);
		// Set the explosion position to the player position
		explosion.transform.position = transform.position;
	}

	void PlayGreenExplosionAnimation(){
		// Instantiate the explosion
		GameObject greenExplosion = (GameObject)Instantiate(GreenExplosion);
		// Set the explosion position to the player position
		greenExplosion.transform.position = transform.position;
	}

	/*
	 * PUBLIC functions
	 * */

	// GameManager will call here when the PlayButton is clicked
	public void Init () {
		lives = maxLives;
		LivesTextUI.text = lives.ToString ();
		// Reset the player position to initial position
		transform.position = new Vector2(0,0);
		gameObject.SetActive (true);
	}
}