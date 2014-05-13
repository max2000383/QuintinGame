using UnityEngine;
using System.Collections;

public class OrbController : MonoBehaviour {
	public float speed;
	public bool collected;
	GameObject orbCameraTarget;
	GameObject orbLeftTarget;

	// Use this for initialization
	void Start () {
		orbCameraTarget = GameObject.FindGameObjectWithTag ("OrbCameraTarget");
		orbLeftTarget = GameObject.FindGameObjectWithTag ("OrbLeftTarget");
		collected = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!collected) {
			if (Vector3.Distance (gameObject.transform.position, orbCameraTarget.transform.position) < 1.2)
				Destroy (gameObject);
			else 
				transform.position = Vector3.MoveTowards (transform.position, orbCameraTarget.transform.position, Time.deltaTime * speed);
		}
		else {
			if (Vector3.Distance (gameObject.transform.position, orbLeftTarget.transform.position) > 0.1)
				transform.position = Vector3.MoveTowards (transform.position, orbLeftTarget.transform.position, Time.deltaTime * 4.5f);

		}
	}

	void OnTriggerEnter (Collider trigger) {
		Debug.Log ("Collision");
		if (trigger.gameObject.tag == "Player")
			collected = true;
	}
}