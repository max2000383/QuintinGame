using UnityEngine;
using System.Collections;

public class RingOrbInstantiate : MonoBehaviour {
	public GameObject orbPrefab;
	private int itemType;
	//public GameObject orb;
	public int colorRef;


	// Use this for initialization
	void Start () {

	
	}
	public void startup(){
		Debug.Log ("RINGORBINSTANTIATE SHOULD NOT HAVE BEEN CALLED");

	}
	public GameObject getGameObject(){
		return gameObject;

	}
	public int getColorRef(){
		return colorRef;
	}
	// Update is called once per frame
	void Update () {
	}
}
