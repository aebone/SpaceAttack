using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HighScores : MonoBehaviour {

	public GameObject text1, text2, text3;
	public GameObject nametext1, nametext2, nametext3;
	Text a, b, c;
	Text namea, nameb, namec;
	int first, second, third;
	string namefirst, namesecond, namethird;

	void Start() {
		UpdateLeaderboard ();
	}

	public void UpdateLeaderboard() {
		// Get the TextUI components that show the scores

		//
		a=text1.GetComponent<Text>();
		b=text2.GetComponent<Text>();
		c=text3.GetComponent<Text>();

		namea=nametext1.GetComponent<Text>();
		nameb=nametext2.GetComponent<Text>();
		namec=nametext3.GetComponent<Text>();
		//


		//
		first = PlayerPrefs.GetInt("firstPlaceKey", 0);
		second = PlayerPrefs.GetInt("secondPlaceKey", 0);
		third = PlayerPrefs.GetInt("thirdPlaceKey", 0);

		namefirst = PlayerPrefs.GetString("nameFirstPlaceKey", "You can be here");
		namesecond = PlayerPrefs.GetString("nameSecondPlaceKey", "You can be here");
		namethird = PlayerPrefs.GetString("nameThirdPlaceKey", "You can be here");
		//
	

		//
		a.text = first.ToString ();
		b.text = second.ToString ();
		c.text = third.ToString();

		namea.text = namefirst;
		nameb.text = namesecond;
		namec.text = namethird;
		//
	}

}
