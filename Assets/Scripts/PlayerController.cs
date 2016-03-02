using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 3.5f;
	public GameObject PlayerBullet; // Reference to the PlayerBullet prefab
	public GameObject GunPosition; // Reference to the empty PlayerGun object (starting bullet point)

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		// Fire bullets when the spacebar is pressed
		if (Input.GetKeyDown("space")){
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
}
