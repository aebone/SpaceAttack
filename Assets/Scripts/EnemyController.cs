using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public float speed = 1.5f;
	public GameObject Explosion;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// Find the screen bottom-left limit to the player's movement based on the Camera
		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2 (0,0)); //bottom-left point (min.x, min.y)

		// Move down the enemy
		transform.position = new Vector2(transform.position.x, transform.position.y - speed * Time.deltaTime);

		// If the enemy reach the bottom-left, destroy it
		if(transform.position.y < min.y) {
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D collider) {
		// If the enemy collides with the Player ship or the Player bullet, destroy it
		if (collider.tag == "PlayerTag" || collider.tag == "PlayerBulletTag" ) {
			PlayAnimation ();
			Destroy (gameObject);
		}
	}

	void PlayAnimation() {
		GameObject explosion = (GameObject)Instantiate (Explosion);

		// Set the explosion position to the enemy position
		explosion.transform.position = transform.position;
	}
}
