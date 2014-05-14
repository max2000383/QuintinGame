using UnityEngine;
using System.Collections;

public class surferController : MonoBehaviour {
	private Vector3 direction;
	public float force = 1.0f;
	public float smoothTime = 0.3F;
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
	private bool outsideRing;

	
	
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
		northEast = GameObject.Find ("Northeast").transform.position;
		northWest = GameObject.Find ("NorthWest").transform.position;
		target = home;
		outsideRing = false;


	}
	
	// Update is called once per frame
	void Update() {

		if (returnHome) {
			target = home;
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

			transform.position = Vector3.Lerp (transform.position, target, Time.deltaTime);
				
			//transform.position = Vector3.Slerp (transform.position, target, Time.deltaTime * speed);

	}

	IEnumerator WaitCoroutine(){
		yield return new WaitForSeconds (2);
		returnHome = true;
	}

	void TargetHome(){
		StopCoroutine ("WaitCoroutine");
		outsideRing = false;
		target = home;
		StartCoroutine ("WaitCoroutine");
	}

	void TargetLeft(){
		StopCoroutine ("WaitCoroutine");
		outsideRing = false;
		target = left;
		StartCoroutine ("WaitCoroutine");
	}

	void TargetRight(){
		StopCoroutine ("WaitCoroutine");
		outsideRing = false;
		target = right;
		StartCoroutine ("WaitCoroutine");
	}

	void TargetUp(){
		StopCoroutine ("WaitCoroutine");
		outsideRing = false;
		target = up;
		StartCoroutine ("WaitCoroutine");
	}

	void TargetDown(){
		StopCoroutine ("WaitCoroutine");
		outsideRing = false;
		target = down;
		StartCoroutine ("WaitCoroutine");
	}

	void TargetNorth(){
		StopCoroutine ("WaitCoroutine");
		outsideRing = true;
		target = north;
		StartCoroutine ("WaitCoroutine");
	}

	void TargetSouth(){
		StopCoroutine ("WaitCoroutine");
		outsideRing = true;
		target = south;
		StartCoroutine ("WaitCoroutine");
	}

	void TargetEast(){
		StopCoroutine ("WaitCoroutine");
		outsideRing = true;
		target = east;
		StartCoroutine ("WaitCoroutine");
	}

	void TargetWest(){
		StopCoroutine ("WaitCoroutine");
		outsideRing = true;
		target = west;
		StartCoroutine ("WaitCoroutine");
	}

	void TargetNorthEast(){
		StopCoroutine ("WaitCoroutine");
		outsideRing = true;
		target = northEast;
		StartCoroutine ("WaitCoroutine");
	}

	void TargetSouthWest(){
		StopCoroutine ("WaitCoroutine");
		outsideRing = true;
		target = southWest;
		StartCoroutine ("WaitCoroutine");
	}

	void TargetNorthWest(){
		StopCoroutine ("WaitCoroutine");
		outsideRing = true;
		target = northWest;
		StartCoroutine ("WaitCoroutine");
	}

	void TargetSouthEast(){
		StopCoroutine ("WaitCoroutine");
		outsideRing = true;
		target = southEast;
		StartCoroutine ("WaitCoroutine");
	}


}



