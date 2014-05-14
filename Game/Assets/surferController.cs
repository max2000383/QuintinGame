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
	private Vector3 target;
	private float speed;

	
	
	// Use this for initialization
	void Start () {
		home = GameObject.Find ("Home").transform.position;
		left = GameObject.Find ("Left").transform.position;
		right = GameObject.Find ("Right").transform.position;
		up = GameObject.Find ("Up").transform.position;
		down = GameObject.Find ("Down").transform.position;
		target = home;
	}
	
	// Update is called once per frame
	void Update() {

		if (Input.GetKeyDown (KeyCode.LeftArrow))
			target = left;

		if (Input.GetKeyDown (KeyCode.RightArrow))
			target = right;

		if (Input.GetKeyDown (KeyCode.UpArrow))
			target = up;

		if (Input.GetKeyDown (KeyCode.DownArrow))
			target = down;

		transform.position = Vector3.Lerp (transform.position, target, Time.deltaTime);
				
		

	}


}
