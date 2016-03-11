using UnityEngine;
using System.Collections;

public class Star : MonoBehaviour {

	public float speed; // Will recieve the value from the StarSpawn
	
	// Update is called once per frame
	void Update () {
		// Update the stars position
		transform.position = new Vector2(transform.position.x, transform.position.y + speed * Time.deltaTime);

		// This is the bottom left of the screen
		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2(0,0));
		// This is the top right of the screen
		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2(1,1));

		// If the star goes outside the screen on the bottom, 
		// position the star on the top edge of the screen, 
		// radomly between the left and right side of the screen
		if(transform.position.y < min.y) {
			transform.position = new Vector2 (Random.Range(min.x, max.x), max.y);
		}
	}
}
