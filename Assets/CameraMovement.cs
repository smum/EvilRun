using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CameraMovement : MonoBehaviour {

	public float interpVelocity;
	public float minDistance;
	public float followDistance;
	public GameObject target;
	public Vector3 offset;
	Vector3 targetPos;
	public Text scoreText;
	public float score;
	public GameObject restartButton;
	public AudioClip startSFX;
	public AudioClip deathSFX;
	public AudioSource source;
	private float vol = 1;

	// Use this for initialization
	void Start () {
		targetPos = transform.position;
		score = 0;
		restartButton.SetActive(false);
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (target != null) {
			Vector3 posNoZ = transform.position;
			posNoZ.z = target.transform.position.z;

			Vector3 targetDirection = (target.transform.position - posNoZ);

			interpVelocity = targetDirection.magnitude * 5f;

			targetPos = transform.position + (targetDirection.normalized * interpVelocity * Time.deltaTime);

			transform.position = Vector3.Lerp( transform.position, targetPos + offset, 0.25f);

			score += Time.deltaTime;
			scoreText.text = "Time: " + (int)score;
		} else if (target == null) {
			restartButton.SetActive(true);
		}
	}

	public void RestartGame () {
		source.PlayOneShot(startSFX, vol);
		Invoke("LoadLevel", 2);
	}

	void LoadLevel() {
		Application.LoadLevel("Level1");
	}
}
