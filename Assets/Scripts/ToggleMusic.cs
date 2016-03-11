using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ToggleMusic : MonoBehaviour {

	public GameObject BackgroundMusic;
	
	// Update is called once per frame
	void Update () {
		if (gameObject.GetComponent<Toggle> ().isOn) {
			BackgroundMusic.SetActive (true);
		} else {
			BackgroundMusic.SetActive (false);
		}
	}
}
