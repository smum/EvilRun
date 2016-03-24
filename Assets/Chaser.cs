using UnityEngine;
 using System.Collections;

 public class Chaser : MonoBehaviour {

    public Transform target;//set target from inspector instead of looking in Update
    public float speed;
		public float maxHeight;
    public AudioClip deathSFX;
  	private AudioSource source;
    public float score;
    public CameraMovement cameraMovement;

     void Start () {
       source = GetComponent<AudioSource>();
       score = cameraMovement.score;
     }

  void Update() {
    score = cameraMovement.score;
    if (target != null && score >= 30) {
      Quaternion rotation = Quaternion.LookRotation(target.transform.position - transform.position, transform.TransformDirection(Vector3.up));
      transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
        if (Vector3.Distance(transform.position, target.position) > 1f) {
            transform.Translate(new Vector3(speed * Time.deltaTime, maxHeight * Time.deltaTime, 0) );
        }

        if (transform.position.y < -20) {
    			transform.position = new Vector3(target.transform.position.x, target.transform.position.y + 20f, 0);
    		}
    	}
    }

  /*void OnCollisionEnter2D(Collision2D hitByPlayer) {
    float vol = 1f;

    if (target != null) {
      if (hitByPlayer.gameObject.tag == "Player") {
        source.PlayOneShot(deathSFX, vol);
        Destroy(target.gameObject);
      }
    }
	}*/
}
