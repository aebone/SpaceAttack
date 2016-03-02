using UnityEngine;
using System.Collections;

public class PlayerBullet : MonoBehaviour {

	public float speed = 8f;

	// Use this for initialization
	void Start () {
	//	speed = 8f;
	}

	// Update is called once per frame
	void Update () {
		// Update the bullets new position
		transform.position = new Vector2(transform.position.x, transform.position.y + speed * Time.deltaTime);

		// Find the top-right of the screen
		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2(1,1));

		// If the bullet went outside the screen on top, then destroy the bullet
		if (transform.position.y > max.y) {
			Destroy (gameObject);
		}
	}
}
