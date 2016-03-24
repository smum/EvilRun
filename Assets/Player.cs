using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	bool alive = true;
	public float speed;
	public float maxHeight;
	public AudioClip jumpSFX;
	public AudioClip deathSFX;
	private AudioSource source;
	public static float distanceTraveled;

	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update() {
		if (gameObject != null) {
			distanceTraveled = transform.localPosition.x;
			float vol = 1f;

    	if(Input.GetKey(KeyCode.UpArrow)) {
        	transform.position += Vector3.right * speed * Time.deltaTime;
    	}

			if(Input.GetKey(KeyCode.DownArrow)) {
        	transform.position += Vector3.left * speed * Time.deltaTime;
    	}

			if(Input.GetKeyDown("space")) {
				source.PlayOneShot(jumpSFX, vol);
			}

			if(Input.GetKey(KeyCode.Space)) {
      	transform.position += Vector3.up * maxHeight * Time.deltaTime;
    	}

    	if(Input.GetKey(KeyCode.LeftArrow)) {
      	transform.Rotate (Vector3.forward * 15);
    	}

    	if(Input.GetKey(KeyCode.RightArrow)) {
        transform.Rotate (Vector3.forward * -15);
    	}

			if (transform.position.y <= -50) {
				Destroy(gameObject);

			}
		}
 	}
}
