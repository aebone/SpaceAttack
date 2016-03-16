using UnityEngine;
using System.Collections;

public class FriendController : MonoBehaviour {

	public float speed = 1.5f;
	public GameObject Explosion; // Reference to the Explosion prefab
	public GameObject FriendMessage; // Reference to the FriendMessage prefab

	GameObject ScoreTextUI;

	void Start() {
		ScoreTextUI = GameObject.FindGameObjectWithTag ("ScoreTextTag");
	}

	// Update is called once per frame
	void Update () {
		// Get the screen limit based on the Camera
		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0,0));
		// Move the friend
		transform.position = new Vector2 (transform.position.x, transform.position.y - speed * Time.deltaTime);
		// Destroy it if below the limit
		if (transform.position.y < min.y) {
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter2D (Collider2D collider) {
		if (collider.tag == "PlayerTag" || collider.tag == "PlayerBulletTag" ) {	
			PlayExplosionAnimation ();
			// Reduce 5 points to the score using the setScore method on the GameScore class
			ScoreTextUI.GetComponent<GameScore>().Score -= 5;
			Destroy (gameObject);
		}
		if (collider.tag == "PlayerBulletTag") {
			PlayMessage ();
		}
	}

	void PlayExplosionAnimation () {
		GameObject explosion = (GameObject)Instantiate (Explosion);

		// Set the explosion on the gameObject position;
		explosion.transform.position = transform.position;
	}

	void PlayMessage () {
		GameObject message = (GameObject)Instantiate (FriendMessage);
		message.transform.position = transform.position;
	}
}