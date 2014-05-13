using UnityEngine;
using System.Collections;

public class OrbController : MonoBehaviour {
	public float speed;
	public bool collected;
	public int color;
	GameObject orbCameraTarget;
	GameObject orbLeftTarget;
	Vector3 destination;
	Vector3 beginning;

	// Use this for initialization
	void Start () {
		//orbCameraTarget = GameObject.FindGameObjectWithTag ("OrbCameraTarget");
		//orbLeftTarget = GameObject.FindGameObjectWithTag ("OrbLeftTarget");
		collected = false;

		destination=gameObject.transform.position;
		beginning=destination;
	}
	void setDestination(Vector3 toSet){
		destination=toSet;

	}
	// Update is called once per frame
	void Update () {
		if(collected){
			Debug.Log("found orb");
			//GameController.addOrb(gameObject);
			if(Vector3.Distance(destination,gameObject.transform.position)>1)Vector3.Lerp(beginning,destination,0.5f);

		}
		transform.position=new Vector3(transform.position.x,Time.deltaTime*speed+transform.position.y,transform.position.z);
		
		if(transform.position.y>6)Destroy(gameObject);
		/*
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
		*/
	}

	void OnTriggerEnter (Collider trigger) {
		Debug.Log ("Collision");
		if (trigger.gameObject.tag == "Player")
			collected = true;
	}
}