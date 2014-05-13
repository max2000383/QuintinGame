using UnityEngine;
using System.Collections;

public class MouseClick : MonoBehaviour {
	bool clicked;

	// Use this for initialization
	void Start () {
		clicked = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (clicked)
			transform.position = Vector3.Lerp (transform.position, new Vector3 (0, 0, 0), 0.5f * Time.deltaTime * 15); 
				Destroy (gameObject, 1.5f);
	}

	void OnMouseDown(){
		Debug.Log ("Click");
		if(gameObject.GetComponent<OrbControllerMax> ().collected){
		gameObject.GetComponent<OrbControllerMax> ().collected = false;
		gameObject.GetComponent<OrbControllerMax> ().hitMarker = false;
		clicked = true;}
	}
}

