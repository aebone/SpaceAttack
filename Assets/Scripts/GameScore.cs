using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameScore : MonoBehaviour {

	Text scoreTextUI;
	int score = 0; // Keep the score 

	// Variable with get and set to receive value to add or remove from other classes
	public int Score
	{
		get {
			return this.score;
		}
		set {
			this.score = value;
			UpdatScoreTextUI ();
		}
	}

	// Use this for initialization
	void Start () {
		//get the text ui component of this gameobject
		scoreTextUI = GetComponent<Text>();
	}

	// Update score text
	void UpdatScoreTextUI() {
		// Don't let the score be negative
		if (score < 0)
			score = 0;
		else {
			string scoreText = string.Format ("{0:00000}", score);
			scoreTextUI.text = scoreText;
		}
	}
}
