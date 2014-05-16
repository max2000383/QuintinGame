using UnityEngine;
using System.Collections;

public class RingCollect : MonoBehaviour {

	private Component[] scripts;
	public float speed = 1.0f;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		transform.position=new Vector3(transform.position.x,Time.deltaTime*speed+transform.position.y,transform.position.z);
	}

	void OnTriggerEnter(Collider myCol){
		scripts = GetComponentsInChildren<RingOrbInstantiate> ();
		if (myCol.gameObject.tag == "Player") {
			foreach (RingOrbInstantiate location in scripts ){
				location.orb.GetComponent<OrbControllerMax>().collected = true;
			}
		}
	}
}
