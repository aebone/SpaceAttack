using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	// Referring objects to be managed *All objects on hierarchy
	public GameObject PlayButton;
	public GameObject Player;
	public GameObject EnemySpawner;
	public GameObject GameOver;
	public GameObject ScoreTextUI;
	public GameObject FriendSpawner;

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
			break;
		case GameManagerState.GameOver:
			// Stop the enemy spawner when the player dies
			EnemySpawner.GetComponent<EnemySpawner>().UnscheduleEnemySpawner();
			// Stop the friend spawner when the player dies
			FriendSpawner.GetComponent<FriendSpawner>().UnscheduleFriendSpawner();
			// Diplay game over image
			GameOver.SetActive(true);
			// Change the manager state to opening state after 6 seconds
			Invoke("ChangeToOpeningState", 6f);
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
