using UnityEngine;
using System.Collections;

public class OrbController : MonoBehaviour {
	public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance (gameObject.transform.position, Camera.main.transform.position) < 1.5)
			Destroy (gameObject);
		else 
			transform.position = Vector3.MoveTowards (transform.position, Camera.main.transform.position, Time.deltaTime * speed);
	}
}