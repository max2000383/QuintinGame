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
	private Vector3 target;
	private float speed;
	private bool returnHome = false;
	private bool fromOutsideRing;
	private bool toOutsideRing;

	
	
	// Use this for initialization
	void Start () {
		speed = 1.0f;
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

		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			TargetLeft();
			}

		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			TargetRight();
			}

		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			TargetUp ();
			}

		if (Input.GetKeyDown (KeyCode.DownArrow)){
			TargetDown ();
			}

			transform.position = Vector3.Lerp (transform.position, target, Time.deltaTime * speed);
				
			transform.position = Vector3.Slerp (transform.position, target, Time.deltaTime * speed);

	}

	IEnumerator WaitCoroutine(){
		yield return new WaitForSeconds (waitTime);
		returnHome = true;
	}

	void TargetHome(){
		StopCoroutine ("WaitCoroutine");
		toOutsideRing = false;
		target = home;
		fromOutsideRing = false;
		StartCoroutine ("WaitCoroutine");
	}

	void TargetLeft(){
		StopCoroutine ("WaitCoroutine");
		toOutsideRing = false;
		target = left;
		fromOutsideRing = false;
		StartCoroutine ("WaitCoroutine");
	}

	void TargetRight(){
		StopCoroutine ("WaitCoroutine");
		toOutsideRing = false;
		target = right;
		fromOutsideRing = false;
		StartCoroutine ("WaitCoroutine");
	}

	void TargetUp(){
		StopCoroutine ("WaitCoroutine");
		toOutsideRing = false;
		target = up;
		fromOutsideRing = false;
		StartCoroutine ("WaitCoroutine");
	}

	void TargetDown(){
		StopCoroutine ("WaitCoroutine");
		toOutsideRing = false;
		target = down;
		fromOutsideRing = false;
		StartCoroutine ("WaitCoroutine");
	}

	void TargetNorth(){
		StopCoroutine ("WaitCoroutine");
		toOutsideRing = true;
		target = north;
		fromOutsideRing = true;
		StartCoroutine ("WaitCoroutine");
	}

	void TargetSouth(){
		StopCoroutine ("WaitCoroutine");
		toOutsideRing = true;
		target = south;
		fromOutsideRing = true;
		StartCoroutine ("WaitCoroutine");
	}

	void TargetEast(){
		StopCoroutine ("WaitCoroutine");
		toOutsideRing = true;
		target = east;
		fromOutsideRing = true;
		StartCoroutine ("WaitCoroutine");
	}

	void TargetWest(){
		StopCoroutine ("WaitCoroutine");
		toOutsideRing = true;
		target = west;
		fromOutsideRing = true;
		StartCoroutine ("WaitCoroutine");
	}

	void TargetNorthEast(){
		StopCoroutine ("WaitCoroutine");
		toOutsideRing = true;
		target = northEast;
		fromOutsideRing = true;
		StartCoroutine ("WaitCoroutine");
	}

	void TargetSouthWest(){
		StopCoroutine ("WaitCoroutine");
		toOutsideRing = true;
		target = southWest;
		fromOutsideRing = true;
		StartCoroutine ("WaitCoroutine");
	}

	void TargetNorthWest(){
		StopCoroutine ("WaitCoroutine");
		toOutsideRing = true;
		target = northWest;
		fromOutsideRing = true;
		StartCoroutine ("WaitCoroutine");
	}

	void TargetSouthEast(){
		StopCoroutine ("WaitCoroutine");
		toOutsideRing = true;
		target = southEast;
		fromOutsideRing = true;
		StartCoroutine ("WaitCoroutine");
	}


}



