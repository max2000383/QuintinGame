using UnityEngine;
using System.Collections;

public class OrbControllerMax : MonoBehaviour {
	public float speed;
	public float moveSpeed;
	public bool collected;
	public bool process;
	public bool beingDragged;
	public GameObject player;
	public bool hitMarker;
	public bool clicked;
	public int color;
	//public script GameController;
	GameObject orbCameraTarget;
	GameObject orbLeftTarget;
	public Vector3 destination;
	Vector3 beginning;
	Vector3 initialDestination;

	// Use this for initialization
	void Start () {
		//orbCameraTarget = GameObject.FindGameObjectWithTag ("OrbCameraTarget");
		//orbLeftTarget = GameObject.FindGameObjectWithTag ("OrbLeftTarget");
		collected = false;
		hitMarker=false;
		clicked=false;//misnomes, means process as a motion.
		beingDragged=false; //make it free from destination, but not moveable.
		speed=1;
		process=false;
		player = GameObject.Find ("Surfer");
		moveSpeed=4;
		//destination=gameObject.transform.position;
		beginning=destination;
	}
	public void setDestination(Vector3 toSet){
		destination=toSet;

	}
	public void setInitialDestination(Vector3 toSet){
		initialDestination=toSet;
		
	}
	public bool isCollected(){
		return collected;
	}
	public void isProcessed(Vector3 Dest){
		process=true;
		destination=Dest;
		//beginning=transform.position;

	}
	// Update is called once per frame
	void Update () {
		if(process){
			if(Vector3.Distance(destination,gameObject.transform.position)>0.1f)transform.position=Vector3.MoveTowards(transform.position,player.transform.position,0.5f*Time.deltaTime*moveSpeed);
			else destroyMe();
		}
		else if(collected||hitMarker||clicked){
			Debug.Log("found orb");
			//GameController.addOrb(gameObject);
			beginning=transform.position;
			if(Vector3.Distance(destination,gameObject.transform.position)>0.01f)transform.position=Vector3.Lerp(beginning,destination,0.5f*Time.deltaTime*moveSpeed);
			//else if(clicked)destroyMe();

		}
		else transform.position=new Vector3(transform.position.x,Time.deltaTime*speed+transform.position.y,transform.position.z);
		
		//if(transform.position.y>6)Destroy(gameObject);
		if(transform.position.y>5&&!hitMarker&&!process){
			hitMarker=true;
			collected=true;
			//destination=initialDestination;
		}//replace this with collided. I don't trust it. Collided, that is.
		//if(Vector3.Distance(transform.position,initialDestination)<0.25)collected=true;
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
	void destroyMe(){
		Destroy(gameObject);
	}
	void OnMouseDown(){
		Debug.Log ("Click");
		if(collected){
			clicked = true;
		}
	}
	public bool isClicked(){
		return clicked;
	}

	void OnTriggerEnter (Collider trigger) {
		Debug.Log ("Collision");
		if (trigger.gameObject.tag == "Player")collected=collected;
			//collected = true;
	}
}