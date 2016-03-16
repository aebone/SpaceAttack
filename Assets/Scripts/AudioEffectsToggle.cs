using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AudioEffectsToggle : MonoBehaviour {
	public GameObject Player;
	public GameObject Explosion;
	public GameObject GreenExplosion;

	// Update is called once per frame
	void Update () {
		AudioSource player = Player.GetComponent<AudioSource> ();
		AudioSource explosion = Explosion.GetComponent<AudioSource> ();
		AudioSource greenExplosion = GreenExplosion.GetComponent<AudioSource> ();

		if (gameObject.GetComponent<Toggle> ().isOn) {
			player.mute = false;
			explosion.mute = false;
			greenExplosion.mute = false;
		} else {
			player.mute = true;
			explosion.mute = true;
			greenExplosion.mute = true;
		}
	}
}
