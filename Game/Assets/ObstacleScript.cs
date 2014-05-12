using UnityEngine;
using System.Collections;

public class ObstacleScript : MonoBehaviour {
	public float speed=1;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		transform.position=new Vector3(transform.position.x,Time.deltaTime*speed+transform.position.y,transform.position.z);

		if(transform.position.y>6)Destroy(gameObject);
	}
}
