using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	// Referring objects to be managed *All objects on hierarchy
	public GameObject PlayButton;
	public GameObject HighScoreButton;
	public GameObject InstructionsButton;
	public GameObject Player;
	public GameObject EnemySpawner;
	public GameObject GameOver;
	public GameObject ScoreTextUI;
	public GameObject FriendSpawner;
	public GameObject TimeCounterGO;
	public GameObject Logo;
	public GameObject InputName;

	// Allow to create GameManagerState object to manage the game state using switch case
	public enum GameManagerState
	{
		Opening,
		Playing,
		GameOver
	}

	GameManagerState state;

	// Use this for initialization
	void Start () {
		// Start with Opening state
		state = GameManagerState.Opening;
	}
	
	// Function to manage the state
	void UpdateGameState () {
		switch (state) {
		case GameManagerState.Opening:
			// Hide GameOver image
			GameOver.SetActive(false);
			// Set the PlayButton visible
			PlayButton.SetActive(true);
			// Show logo
			Logo.SetActive(true);
			// Show Instructions Button
			InstructionsButton.SetActive(true);
			// Show HighScores Button
			HighScoreButton.SetActive(true);
			// Hide InputName
			InputName.SetActive(false);
			break;
		case GameManagerState.Playing:
			// Set initial score to 0 - needed in case player dies and plays again
			ScoreTextUI.GetComponent<GameScore>().Score = 0; 
			// Set the PlayButton invisible
			PlayButton.SetActive(false);
			// Active the Player and init its lives
			Player.GetComponent<PlayerController>().Init();
			// Start Enemy spawner
			EnemySpawner.GetComponent<EnemySpawner>().ScheduleEnemySpawner();
			// Start Friend spawner
			FriendSpawner.GetComponent<FriendSpawner>().ScheduleFriendSpawner();
			// Start the time counter
			TimeCounterGO.GetComponent<TimeCounter>().StartTimeCounter();
			// Hide the logo
			Logo.SetActive(false);
			// Hide Instructions Button
			InstructionsButton.SetActive(false);
			// Hide HighScores Button
			HighScoreButton.SetActive(false);
			break;
		case GameManagerState.GameOver:
			// Stop the time couter
			TimeCounterGO.GetComponent<TimeCounter>().StopTimeCounter();
			// Stop the enemy spawner when the player dies
			EnemySpawner.GetComponent<EnemySpawner>().UnscheduleEnemySpawner();
			// Stop the friend spawner when the player dies
			FriendSpawner.GetComponent<FriendSpawner>().UnscheduleFriendSpawner();
			// Diplay game over image
			GameOver.SetActive(true);
			// Check score to keep or not
			ScoreTextUI.GetComponent<GameScore>().OnGameOver(); 
			break;
		}
	}

	/* 
	 * PUBLIC functions
	 * */

	// Function to set the game state, will receive argument from other classes
	public void SetGameState(GameManagerState state) {
		this.state = state;
		UpdateGameState ();
	}

	// When PlayButton is clicked
	public void StartPlaying () {
		state = GameManagerState.Playing;
		UpdateGameState ();
	}

	// Change to opening state when player dies
	public void ChangeToOpeningState () {
		SetGameState (GameManagerState.Opening);
	}


}
