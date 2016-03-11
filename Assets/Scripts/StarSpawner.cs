using UnityEngine;
using System.Collections;

public class StarSpawner : MonoBehaviour {

	public GameObject Star; // Reference to Star prefab
	int maxStars = 30; // Max numbers of stars

	// Array of colors
	Color[] starColors = {
		new Color(0.5f, 0.5f, 1f), //blue
		new Color(0f, 1f, 1f), //green
		new Color(1f, 1f, 0), //yellow
		new Color(1f, 0, 0) //red
	};

	// Use this for initialization
	void Start () {
		//this is the bottom-left of the screen
		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0,0));

		//this is the top-riight of the screen
		Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1,1));

		// Loop to create the stars
		for (int i = 0; i < maxStars; i++) {
			GameObject star = (GameObject)Instantiate (Star);

			// Set the color in the star
			star.GetComponent<SpriteRenderer>().color = starColors[i % starColors.Length];

			// Set the position of the star (random x and random y)
			star.transform.position = new Vector2(Random.Range(min.x, max.x), Random.Range(min.y, max.y));

			// Set a random speed for the star
			star.GetComponent<Star>().speed = -(1f * Random.value + 0.5f);

			// /make the star a child of the StarGenerator
			star.transform.parent = transform;
		}
	}
}
