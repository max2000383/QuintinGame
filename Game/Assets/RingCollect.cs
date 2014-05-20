using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RingCollect : MonoBehaviour {
	private Component[] scripts;
	public float speed = 1.0f;
	bool test;
	public List<GameObject> theOrbs = new List<GameObject>();
	// Use this for initialization
	void Start () {

	}
	public void startup(){
		scripts = GetComponentsInChildren<RingOrbInstantiate> ();
		/*
		foreach (RingOrbInstantiate location in scripts ){
			location.startup();
			theOrbs.Add(location.getGameObject());
		}
		*/
	}
	public List<GameObject> getOrbs(){
		return theOrbs;
	}
	public Component[] getScripts(){
		return scripts;

	}
	// Update is called once per frame
	void Update () {
		transform.position=new Vector3(transform.position.x,Time.deltaTime*speed+transform.position.y,transform.position.z);
		if(transform.position.y>8)Destroy(gameObject);
	}

	void OnTriggerEnter(Collider myCol){
		scripts = GetComponentsInChildren<RingOrbInstantiate> ();
		if (myCol.gameObject.tag == "Player") {
			foreach (RingOrbInstantiate location in scripts ){
				//location.orb.GetComponent<OrbControllerMax>().collected = true;
				test=true;
			}
		}
	}
}
