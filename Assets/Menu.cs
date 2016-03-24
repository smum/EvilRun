using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Menu : MonoBehaviour {

	public Button startButton;
	public AudioClip startSFX;
	public AudioSource source;
	private float vol = 1;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void StartGame () {
		source.PlayOneShot(startSFX, vol);
		Invoke("LoadLevel", 2);
	}

	void LoadLevel() {
		Application.LoadLevel("Level1");
	}
}
