using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameScore : MonoBehaviour {

	Text scoreTextUI;
	int score = 0; // Keep the score 

	// References to start keep records 
	int firstPlace = 0;
	int secondPlace = 0;
	int thirdPlace = 0;

	public GameObject PanelHighScores;
	public GameObject GameManager; 
	public GameObject InputName;
	public GameObject MessageHighScore;

	public string username;

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
		// Get the TextUI component of this gameobject
		scoreTextUI = GetComponent<Text>();
		// Get the scores from player prefs if it is there, 0 otherwise.
		firstPlace = PlayerPrefs.GetInt("firstPlaceKey", 0);  
		secondPlace = PlayerPrefs.GetInt("secondPlaceKey", 0);  
		thirdPlace = PlayerPrefs.GetInt("thirdPlaceKey", 0);  
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

	void SendPrefs(string user) {
		InputName.SetActive (false);
		MessageHighScore.SetActive (false);
		if (score > firstPlace) {
			PlayerPrefs.SetInt ("firstPlaceKey", score);
			PlayerPrefs.SetString ("nameFirstPlaceKey", user);
			PlayerPrefs.Save ();
		} else if (score > secondPlace && score <= firstPlace) {
			PlayerPrefs.SetInt ("secondPlaceKey", score);
			PlayerPrefs.SetString ("nameSecondPlaceKey", user);
			PlayerPrefs.Save ();
		} else if (score > thirdPlace && score <= secondPlace) {
			PlayerPrefs.SetInt ("thirdPlaceKey", score);
			PlayerPrefs.SetString ("nameThirdPlaceKey", user);
			PlayerPrefs.Save ();
		} 
		PanelHighScores.GetComponent<HighScores> ().UpdateLeaderboard ();
		GameManager.GetComponent<GameManager>().ChangeToOpeningState();
	}

	public void OnGameOver() {
		if (score > thirdPlace) 
			Invoke ("ShowHighScorePanel", 3f);
		else
			GameManager.GetComponent<GameManager>().Invoke("ChangeToOpeningState", 5f);	
	}

	void ShowHighScorePanel() {
		MessageHighScore.SetActive (true);
		InputName.SetActive(true);
	}

	// Get the username
	public void GetInputString(string name) {
		username = name;
		SendPrefs (username);
	}
}