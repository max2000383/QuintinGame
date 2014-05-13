using UnityEngine;
using System.Collections;

public class OrbControllerMax : MonoBehaviour {
	public float speed;
	public float moveSpeed;
	public bool collected;
	public int color;
	GameObject orbCameraTarget;
	GameObject orbLeftTarget;
	public Vector3 destination;
	Vector3 beginning;

	// Use this for initialization
	void Start () {
		//orbCameraTarget = GameObject.FindGameObjectWithTag ("OrbCameraTarget");
		//orbLeftTarget = GameObject.FindGameObjectWithTag ("OrbLeftTarget");
		collected = false;
		speed=1;
		moveSpeed=1;
		destination=gameObject.transform.position;
		beginning=destination;
	}
	public void setDestination(Vector3 toSet){
		destination=toSet;

	}
	public bool isCollected(){
		return collected;
	}
	// Update is called once per frame
	void Update () {
		if(collected){
			Debug.Log("found orb");
			//GameController.addOrb(gameObject);
			beginning=transform.position;
			if(Vector3.Distance(destination,gameObject.transform.position)>0.25f)transform.position=Vector3.Lerp(beginning,destination,0.5f*Time.deltaTime*moveSpeed);

		}
		else transform.position=new Vector3(transform.position.x,Time.deltaTime*speed+transform.position.y,transform.position.z);
		
		//if(transform.position.y>6)Destroy(gameObject);
		if(transform.position.y>5)collected=true;
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