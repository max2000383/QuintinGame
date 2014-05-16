using UnityEngine;
using System.Collections;

public class RingOrbInstantiate : MonoBehaviour {
	public GameObject orbPrefab;
	private int itemType;
	public GameObject orb;


	// Use this for initialization
	void Start () {
		itemType = Random.Range(0, 4); //0:Left, 1:Up, 2:Right, 3:Down
		
		switch(itemType) {
		case 0:
			GameObject redOrb = Instantiate (orbPrefab, transform.position, Quaternion.identity) as GameObject;
			redOrb.renderer.material.color = Color.red;
			orb = redOrb;
			break;
		case 1:
			GameObject greenOrb = Instantiate (orbPrefab, transform.position, Quaternion.identity) as GameObject;
			greenOrb.renderer.material.color = Color.green;
			orb = greenOrb;
			break;
		case 2:
			GameObject blueOrb = Instantiate (orbPrefab, transform.position, Quaternion.identity) as GameObject;
			blueOrb.renderer.material.color = Color.blue;
			orb = blueOrb;
			break;
		case 3:				
			GameObject yellowOrb = Instantiate (orbPrefab, transform.position, Quaternion.identity) as GameObject;
			yellowOrb.renderer.material.color = Color.yellow;
			orb = yellowOrb;
			break;
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	}
}
