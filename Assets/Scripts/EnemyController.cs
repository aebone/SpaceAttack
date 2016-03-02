using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public float speed = 1.5f;

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
}
