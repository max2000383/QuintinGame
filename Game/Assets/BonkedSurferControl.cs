using UnityEngine;
using System.Collections;

public class BonkedSurferControl : MonoBehaviour {
	private Vector3 direction;
	public float force = 1.0f;
	public float smoothTime = 0.3F;
	private Vector3 velocity = Vector3.zero;
	private Vector3 home;
	//ttt
	private Vector3 left;
	private Vector3 right;
	private Vector3 up;
	private Vector3 down;
	private Vector3 target;
	private float speed;
	private bool returnHome = false;
	
	
	
	// Use this for initialization
	void Start () {
		speed = 1.0f;
		home = GameObject.Find ("Home").transform.position;
		left = GameObject.Find ("Left").transform.position;
		right = GameObject.Find ("Right").transform.position;
		up = GameObject.Find ("Up").transform.position;
		down = GameObject.Find ("Down").transform.position;
		target = home;
	}
	
	// Update is called once per frame
	void Update() {
		
		if (returnHome) {
			target = home;
			returnHome = false;
		}
		
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			StopCoroutine ("WaitCoroutine");
			target = left;
			StartCoroutine ("WaitCoroutine");
		}
		
		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			StopCoroutine ("WaitCoroutine");
			target = right;
			StartCoroutine ("WaitCoroutine");
		}
		
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			StopCoroutine ("WaitCoroutine");
			target = up;
			StartCoroutine ("WaitCoroutine");
		}
		
		if (Input.GetKeyDown (KeyCode.DownArrow)){
			StopCoroutine ("WaitCoroutine");
			target = down;
			StartCoroutine ("WaitCoroutine");
		}
		
		transform.position = Vector3.Lerp (transform.position, target, Time.deltaTime * speed);
		
		
		
	}
	
	IEnumerator WaitCoroutine(){
		yield return new WaitForSeconds (2);
		returnHome = true;
	}
	
	
}
