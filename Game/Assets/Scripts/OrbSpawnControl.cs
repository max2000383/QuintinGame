using UnityEngine;
using System.Collections;

public class OrbSpawnControl : MonoBehaviour {
	public GameObject orbPrefab;

	// Use this for initialization
	void Start () {
		Instantiate (orbPrefab, gameObject.transform.position, gameObject.transform.rotation);
	}
	
	// Update is called once per frame
	void Update () {

	}
}
