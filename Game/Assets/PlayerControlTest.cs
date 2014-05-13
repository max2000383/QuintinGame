using UnityEngine;
using System.Collections;

public class PlayerControlTest : MonoBehaviour {
	public Vector3 playerPosition;
	// Use this for initialization
	void Start () {
		playerPosition = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.position = playerPosition;
		if (Input.GetKey(KeyCode.A)) {
			playerPosition.x -= 0.1f;
		}
		if (Input.GetKey(KeyCode.D)) {
			playerPosition.x += 0.1f;
		}
		if (Input.GetKey(KeyCode.W)) {
			playerPosition.z += 0.1f;
		}
		if (Input.GetKey(KeyCode.S)) {
			playerPosition.z -= 0.1f;
		}
	}
}