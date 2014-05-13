using UnityEngine;
using System.Collections;

public class surferController : MonoBehaviour {
	private Vector3 direction;
	public float force = 1.0f;
	public float smoothTime = 0.3F;
	private Vector3 velocity = Vector3.zero;
	private Vector3 home = new Vector3(0,0,0);
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		direction = Vector3.zero;
		
		//		if (gameObject.transform.position != Vector3.zero) {
		//
		//			rigidbody.AddForce(direction);
		//				}
		
		//transform.position = Vector3.SmoothDamp(transform.position, Vector3.zero, ref velocity, smoothTime, 1.0f, Time.deltaTime);
		
		if (Input.GetKeyUp(KeyCode.LeftArrow)){
			rigidbody.AddForce(new Vector3(-force, 0.0f, 0.0f)*100);
		}
		
		if (Input.GetKeyUp(KeyCode.RightArrow)){
			rigidbody.AddForce(new Vector3(force, 0.0f, 0.0f)*100);
		}
		if (Input.GetKeyUp(KeyCode.UpArrow)){
			rigidbody.AddForce(new Vector3(0.0f, 0.0f,force)*100);
			
		}
		if (Input.GetKeyUp(KeyCode.DownArrow)){
			rigidbody.AddForce(new Vector3(0.0f, 0.0f, -force)*100);
		}
	}
}
