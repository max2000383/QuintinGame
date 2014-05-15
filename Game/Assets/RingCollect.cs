using UnityEngine;
using System.Collections;

public class RingCollect : MonoBehaviour {

	private Component[] scripts;
	// Use this for initialization
	void Start () {
		scripts = GetComponentsInChildren<OrbControllerMax> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider myCol){
		if (myCol.gameObject.tag == "Player") {
			foreach (OrbControllerMax orb in scripts ){
				orb.collected = true;
			}
		}
	}
}
