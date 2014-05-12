using UnityEngine;
using System.Collections;

public class OrbMovement : MonoBehaviour {
	public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//gameObject.transform.position += Camera.main.transform.position * Time.deltaTime;
		transform.position = Vector3.MoveTowards (transform.position, Camera.main.transform.position, Time.deltaTime * speed);
	}
}
