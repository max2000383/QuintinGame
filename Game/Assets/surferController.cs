using UnityEngine;
using System.Collections;

public class surferController : MonoBehaviour {
	private Vector3 direction;
	public float force = 1.0f;
	public float smoothTime = 0.3F;
	public float waitTime;
	private Vector3 velocity = Vector3.zero;
	private Vector3 home;
	private Vector3 left;
	private Vector3 right;
	private Vector3 up;
	private Vector3 down;
	private Vector3 north;
	private Vector3 south;
	private Vector3 east;
	private Vector3 west;
	private Vector3 northEast;
	private Vector3 northWest;
	private Vector3 southEast;
	private Vector3 southWest;
	private int location;
	private Vector3 target;
	public float speed;
	private bool returnHome = false;
	private bool fromOutsideRing;
	private bool toOutsideRing;
	private bool moveUp;
	private bool moveDown;
	private bool moveLeft;
	private bool moveRight;
	
	
	// Use this for initialization
	void Start () {
		speed = 2.0f;
		home = GameObject.Find ("Home").transform.position;
		left = GameObject.Find ("Left").transform.position;
		right = GameObject.Find ("Right").transform.position;
		up = GameObject.Find ("Up").transform.position;
		down = GameObject.Find ("Down").transform.position;
		north = GameObject.Find ("North").transform.position;
		south = GameObject.Find ("South").transform.position;
		east = GameObject.Find ("East").transform.position;
		west = GameObject.Find ("West").transform.position;
		southEast = GameObject.Find ("SouthEast").transform.position;
		southWest = GameObject.Find ("SouthWest").transform.position;
		northEast = GameObject.Find ("NorthEast").transform.position;
		northWest = GameObject.Find ("NorthWest").transform.position;
		target = home;
		location = 1;
		fromOutsideRing = false;
		toOutsideRing = false;
		waitTime = 2.5f;


	}
	
	// Update is called once per frame
	void Update() {

		if (returnHome) {
			TargetHome ();
			returnHome = false;
		}

		switch(location)
		{

		case 1:  // home location
			if (Input.GetKeyDown (KeyCode.LeftArrow) || moveLeft) {
				TargetLeft();
			}

			if (Input.GetKeyDown (KeyCode.RightArrow) || moveRight) {
				TargetRight();
			}

			if (Input.GetKeyDown (KeyCode.UpArrow) || moveUp) {
				TargetUp ();
			}

			if (Input.GetKeyDown (KeyCode.DownArrow) || moveDown){
				TargetDown ();
			}
			break;

		case 2://up location
			if (Input.GetKeyDown (KeyCode.LeftArrow) || moveLeft) {
				TargetLeft ();
			}
			
			if (Input.GetKeyDown (KeyCode.RightArrow) || moveRight) {
				TargetRight ();
			}
			
			if (Input.GetKeyDown (KeyCode.UpArrow) || moveUp) {
				TargetNorth ();
			}
			
			if (Input.GetKeyDown (KeyCode.DownArrow) || moveDown){
				TargetHome ();
			}
			break;

		case 3:// right location
			if (Input.GetKeyDown (KeyCode.LeftArrow) || moveLeft) {
				TargetHome();
			}
			
			if (Input.GetKeyDown (KeyCode.RightArrow) || moveRight) {
				TargetEast();
			}
			
			if (Input.GetKeyDown (KeyCode.UpArrow) || moveUp) {
				TargetUp();
			}
			
			if (Input.GetKeyDown (KeyCode.DownArrow) || moveDown){
				TargetDown ();
			}
			break;

		case 4:  // down location
			if (Input.GetKeyDown (KeyCode.LeftArrow) || moveLeft) {
				TargetLeft ();
			}
			
			if (Input.GetKeyDown (KeyCode.RightArrow) || moveRight) {
				TargetRight ();
			}
			
			if (Input.GetKeyDown (KeyCode.UpArrow) || moveUp) {
				TargetHome();
			}
			
			if (Input.GetKeyDown (KeyCode.DownArrow) || moveDown){
				TargetSouth ();
			}
			break;

		case 5: // left location
			if (Input.GetKeyDown (KeyCode.LeftArrow) || moveLeft) {
				TargetWest();
			}
			
			if (Input.GetKeyDown (KeyCode.RightArrow) || moveRight) {
				TargetHome();
			}
			
			if (Input.GetKeyDown (KeyCode.UpArrow) || moveUp) {
				TargetUp ();
			}
			
			if (Input.GetKeyDown (KeyCode.DownArrow) || moveDown){
				TargetDown ();
			}
			break;

		case 6: // north location
			if (Input.GetKeyDown (KeyCode.LeftArrow) || moveLeft) {
				TargetNorthWest();
			}
			
			if (Input.GetKeyDown (KeyCode.RightArrow) || moveRight) {
				TargetNorthEast();
			}
			
			if (Input.GetKeyDown (KeyCode.UpArrow) || moveUp) {
				TargetNorth ();
			}
			
			if (Input.GetKeyDown (KeyCode.DownArrow) || moveDown){
				TargetHome();
			}
			break;

		case 7: // northeast location
			if (Input.GetKeyDown (KeyCode.LeftArrow) || moveLeft) {
				TargetNorth();
			}
			
			if (Input.GetKeyDown (KeyCode.RightArrow) || moveRight) {
				TargetEast();
			}
			
			if (Input.GetKeyDown (KeyCode.UpArrow) || moveUp) {
				TargetNorth ();
			}
			
			if (Input.GetKeyDown (KeyCode.DownArrow) || moveDown){
				TargetEast ();
			}
			break;

		case 8: // east location
			if (Input.GetKeyDown (KeyCode.LeftArrow) || moveLeft) {
				TargetHome();
			}
			
			if (Input.GetKeyDown (KeyCode.RightArrow) || moveRight) {
				TargetEast();
			}
			
			if (Input.GetKeyDown (KeyCode.UpArrow) || moveUp) {
				TargetNorthEast ();
			}
			
			if (Input.GetKeyDown (KeyCode.DownArrow) || moveDown){
				TargetSouthEast ();
			}
			break;

		case 9:  // southeast location
			if (Input.GetKeyDown (KeyCode.LeftArrow) || moveLeft) {
				TargetSouth();
			}
			
			if (Input.GetKeyDown (KeyCode.RightArrow) || moveRight) {
				TargetEast();
			}
			
			if (Input.GetKeyDown (KeyCode.UpArrow) || moveUp) {
				TargetEast ();
			}
			
			if (Input.GetKeyDown (KeyCode.DownArrow) || moveDown){
				TargetSouth ();
			}
			break;

		case 10:  // south location
			if (Input.GetKeyDown (KeyCode.LeftArrow) || moveLeft) {
				TargetSouthWest();
			}
			
			if (Input.GetKeyDown (KeyCode.RightArrow) || moveRight) {
				TargetSouthEast();
			}
			
			if (Input.GetKeyDown (KeyCode.UpArrow) || moveUp) {
				TargetHome ();
			}
			
			if (Input.GetKeyDown (KeyCode.DownArrow) || moveDown){
				TargetSouth ();
			}
			break;

		case 11:  // southwest location
			if (Input.GetKeyDown (KeyCode.LeftArrow) || moveLeft) {
				TargetWest();
			}
			
			if (Input.GetKeyDown (KeyCode.RightArrow) || moveRight) {
				TargetSouth();
			}
			
			if (Input.GetKeyDown (KeyCode.UpArrow) || moveUp) {
				TargetWest ();
			}
			
			if (Input.GetKeyDown (KeyCode.DownArrow) || moveDown){
				TargetSouth ();
			}
			break;

		case 12: // west location
			if (Input.GetKeyDown (KeyCode.LeftArrow) || moveLeft) {
				TargetWest();
			}
			
			if (Input.GetKeyDown (KeyCode.RightArrow) || moveRight) {
				TargetHome();
			}
			
			if (Input.GetKeyDown (KeyCode.UpArrow) || moveUp) {
				TargetNorthWest ();
			}
			
			if (Input.GetKeyDown (KeyCode.DownArrow) || moveDown){
				TargetSouthWest ();
			}
			break;

		case 13: // northwest location
			if (Input.GetKeyDown (KeyCode.LeftArrow) || moveLeft) {
				TargetWest();
			}
			
			if (Input.GetKeyDown (KeyCode.RightArrow) || moveRight) {
				TargetNorth();
			}
			
			if (Input.GetKeyDown (KeyCode.UpArrow) || moveUp) {
				TargetNorth ();
			}
			
			if (Input.GetKeyDown (KeyCode.DownArrow) || moveDown){
				TargetWest ();
			}
			break;
		}



				
		if (fromOutsideRing == true && toOutsideRing == true) {
				transform.position = Vector3.Slerp (transform.position, target, Time.deltaTime * speed);
				} else {
				transform.position = Vector3.Lerp (transform.position, target, Time.deltaTime * speed);
				}

	}

	IEnumerator WaitCoroutine(){
		yield return new WaitForSeconds (waitTime);
		returnHome = true;
	}

	void TargetHome(){
		StopCoroutine ("WaitCoroutine");
		toOutsideRing = false;
		target = home;
		location = 1;
		fromOutsideRing = false;
		StartCoroutine ("WaitCoroutine");
	}

	void TargetLeft(){
		StopCoroutine ("WaitCoroutine");
		toOutsideRing = false;
		target = left;
		location = 5;
		fromOutsideRing = false;
		StartCoroutine ("WaitCoroutine");
	}

	void TargetRight(){
		StopCoroutine ("WaitCoroutine");
		toOutsideRing = false;
		target = right;
		location = 3;
		fromOutsideRing = false;
		StartCoroutine ("WaitCoroutine");
	}

	void TargetUp(){
		StopCoroutine ("WaitCoroutine");
		toOutsideRing = false;
		target = up;
		location = 2;
		fromOutsideRing = false;
		StartCoroutine ("WaitCoroutine");
	}

	void TargetDown(){
		StopCoroutine ("WaitCoroutine");
		toOutsideRing = false;
		target = down;
		location = 4;
		fromOutsideRing = false;
		StartCoroutine ("WaitCoroutine");
	}

	void TargetNorth(){
		StopCoroutine ("WaitCoroutine");
		toOutsideRing = true;
		target = north;
		location = 6;
		fromOutsideRing = true;
		StartCoroutine ("WaitCoroutine");
	}

	void TargetSouth(){
		StopCoroutine ("WaitCoroutine");
		toOutsideRing = true;
		target = south;
		location = 10;
		fromOutsideRing = true;
		StartCoroutine ("WaitCoroutine");
	}

	void TargetEast(){
		StopCoroutine ("WaitCoroutine");
		toOutsideRing = true;
		target = east;
		location = 8;
		fromOutsideRing = true;
		StartCoroutine ("WaitCoroutine");
	}

	void TargetWest(){
		StopCoroutine ("WaitCoroutine");
		toOutsideRing = true;
		target = west;
		location = 12;
		fromOutsideRing = true;
		StartCoroutine ("WaitCoroutine");
	}

	void TargetNorthEast(){
		StopCoroutine ("WaitCoroutine");
		toOutsideRing = true;
		target = northEast;
		location = 7;
		fromOutsideRing = true;
		StartCoroutine ("WaitCoroutine");
	}

	void TargetSouthWest(){
		StopCoroutine ("WaitCoroutine");
		toOutsideRing = true;
		target = southWest;
		location = 11;
		fromOutsideRing = true;
		StartCoroutine ("WaitCoroutine");
	}

	void TargetNorthWest(){
		StopCoroutine ("WaitCoroutine");
		toOutsideRing = true;
		target = northWest;
		location = 13;
		fromOutsideRing = true;
		StartCoroutine ("WaitCoroutine");
	}

	void TargetSouthEast(){
		StopCoroutine ("WaitCoroutine");
		toOutsideRing = true;
		target = southEast;
		location = 9;
		fromOutsideRing = true;
		StartCoroutine ("WaitCoroutine");
	}

	void OrbReturn(){}


}



