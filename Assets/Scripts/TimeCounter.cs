using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimeCounter : MonoBehaviour {

	Text TextTimeUI; // Reference to the time counter text

	float startTime; 
	float ellapsedTime;
	bool startCounter; // Flag to start count

	int minutes;
	int seconds;

	// Use this for initialization
	void Start () {
		startCounter = false;
		// Get the Text UI component from this gameObject
		TextTimeUI = GetComponent<Text> ();
	}

	// Update is called once per frame
	void Update () {
		if(startCounter) {
			// Compute the ellapsed time
			ellapsedTime = Time.time - startTime;

			minutes = (int)ellapsedTime / 60;
			seconds = (int)ellapsedTime % 60;

			//update the time counter UI Text
			TextTimeUI.text = string.Format("{0:00}:{1:00}", minutes, seconds);
		}
	}

	/*
	 * PUBLIC Functions
	 * */

	// Function to start the time counter when PlayButton is clicked
	public void StartTimeCounter() {
		startTime = Time.time; // Get initial time
		startCounter = true;
	}

	// Function to stop the time counter
	public void StopTimeCounter() {
		startCounter = false;
	}
		
}