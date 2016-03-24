using UnityEngine;
using System.Collections;

public class Hazards : MonoBehaviour {

	public Transform target;
	public AudioClip deathSFX;
	public AudioSource source;
	private float vol = 1;

	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter2D(Collision2D hitByPlayer) {

		if (target != null) {
     	if (hitByPlayer.gameObject.name == "Player") {
				source.PlayOneShot(deathSFX, vol);
         	Destroy(target.gameObject);
     	}
		}
	}
}
