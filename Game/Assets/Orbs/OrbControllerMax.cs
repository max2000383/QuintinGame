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
	public float processSpeed;
	public bool followCursor;
	public int color;
	public float flickDuration;
	Vector3 mousePosition;
	//public script GameController;
	GameObject orbCameraTarget;
	GameObject orbLeftTarget;
	public Vector3 destination;
	Vector3 beginning;
	Vector3 initialDestination;
	public Vector3 oldPosition;//used for the velocity calculation
	Vector3 oldTemp;
	Vector3 rawVelocity;
	public float velocity;
	bool oldTime;

	// Use this for initialization
	void Start () {
		//orbCameraTarget = GameObject.FindGameObjectWithTag ("OrbCameraTarget");
		//orbLeftTarget = GameObject.FindGameObjectWithTag ("OrbLeftTarget");
		collected = false;
		hitMarker=false;
		followCursor=false;
		clicked=false;//misnomes, means process as a motion.
		beingDragged=false; //make it free from destination, but not moveable.
		speed=1;
		processSpeed=4;
		oldTime=false;
		oldPosition=new Vector3(0,0,0);
		rawVelocity=new Vector3(1,2,1);
		velocity=0;
		flickDuration=0.2f;
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
	IEnumerator OldPosition() {
		oldTemp=transform.position;
		yield return new WaitForSeconds(0.2f);
		oldPosition=oldTemp;
		oldTime=true;
	}
	// Update is called once per frame
	void Update () {

		StartCoroutine("OldPosition");
		if(oldTime){
			rawVelocity=transform.position-oldPosition;

			velocity=Mathf.Abs(rawVelocity.x)+Mathf.Abs(rawVelocity.y);

		}
		if(process){
			if(Vector3.Distance(destination,gameObject.transform.position)>0.1f){

				transform.position+=Vector3.Slerp(rawVelocity.normalized,(player.transform.position-transform.position).normalized,0.15f).normalized*0.25f;
				//transform.position=Vector3.Slerp(transform.position,player.transform.position,0.5f*Time.deltaTime*processSpeed);


			}
			//else destroyMe();
		}
		else if(collected||hitMarker||clicked){
			//Debug.Log("found orb");
			//GameController.addOrb(gameObject);
			beginning=transform.position;
			if(Vector3.Distance(destination,gameObject.transform.position)>0.01f)transform.position=Vector3.Lerp(beginning,destination,0.5f*Time.deltaTime*moveSpeed);
			//else if(clicked)destroyMe();

		}
		else transform.position=new Vector3(transform.position.x,Time.deltaTime*speed+transform.position.y,transform.position.z);
		if(followCursor){
			mousePosition = Input.mousePosition;
			Vector3 temp=new Vector3(mousePosition.x,mousePosition.y,8.3f);//todo fix this
			//i don't know why this fucking works
			//but it does.
			mousePosition = Camera.main.ScreenToWorldPoint(temp);
			//fuck it.
			//destination=new Vector3(mousePosition.x,transform.position.y,mousePosition.z);
			//destination=new Vector3(transform.position.x,transform.position.y,transform.position.z);
			destination=new Vector3(mousePosition.x,transform.position.y,mousePosition.z);
			beginning=transform.position;
			if(Vector3.Distance(destination,gameObject.transform.position)>0.01f)transform.position=Vector3.Lerp(beginning,destination,2f*Time.deltaTime*moveSpeed);

			//destination=mousePosition;
		}
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
			collected=false;
			followCursor=true;
		}


	}
	public bool isFollowingCursor(){
		return followCursor;
	}
	void OnMouseUp(){
		if(velocity>0.1f) //CHANGE TRUE TO "VELOCITY IS OVER THRESHOLD"
		{
			clicked=true;
			//process=true;
			processSpeed=velocity*20;
			followCursor=false;
		}
		else
		{
			destination=transform.position;
			collected=true;
			hitMarker=true;
			followCursor=false;
			clicked=false;

		}
	}
	public bool Clicked(){
		return clicked;
	}
	public bool isClicked(){
		return clicked||followCursor;
	}

	void OnTriggerEnter (Collider trigger) {
		if(trigger.gameObject.tag == "Player")collected=collected;
		if(trigger.gameObject.tag == "Player" && clicked){
			string colString = "";
			colString += "\nPlayer: " + player.transform.position.ToString();
			colString += "\nClosest On Bounds: " + trigger.ClosestPointOnBounds(transform.position).ToString();
			Debug.Log(colString);
			Vector3 colPoint = trigger.ClosestPointOnBounds(transform.position);
			Vector3 plaPoint = player.transform.position;
			surferController s = player.GetComponent<surferController>();
			if(!s) {
				Debug.Log("No surferController");
				return;
			}
			if(colPoint.x - plaPoint.x >= 0.4) s.hitByOrb("left");
			else if(colPoint.x - plaPoint.x <= -0.4) s.hitByOrb("right");
			else if(colPoint.z - plaPoint.z >= 0.4) s.hitByOrb("down");
			else if(colPoint.z - plaPoint.x <= -0.4) s.hitByOrb("up");
			else Debug.Log("Dafuq got hit?");
			destroyMe();
		}
	}
}