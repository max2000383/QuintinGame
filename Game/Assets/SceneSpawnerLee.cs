using UnityEngine;
using System.Collections;

public class SceneSpawnerLee : MonoBehaviour {
	private Vector3 home;
	private Vector3 up;
	private Vector3 down;
	private Vector3 left;
	private Vector3 right;
	private Vector3 north;
	private Vector3 south;
	private Vector3 east;
	private Vector3 west;
	private Vector3 northWest;
	private Vector3 northEast;
	private Vector3 southWest;
	private Vector3[] spawn;
	private Vector3 southEast;
	private GameObject lastSpawn;
	public GameObject obstacles;
	private int numObstacles;
	private int location;

	// Use this for initialization
	void Start () {

		numObstacles = 3;


		for (int i = 0; i < numObstacles; ++i) {

			location = Random.Range (0, spawn.Length);
			Instantiate (obstacles, spawn[location], Vector3.zero); 
		}
		home = GameObject.Find ("HomeS").transform.position;
		spawn.ADD ("home");
		left = GameObject.Find ("LeftS").transform.position;
		right = GameObject.Find ("RightS").transform.position;
		up = GameObject.Find ("UpS").transform.position;
		down = GameObject.Find ("DownS").transform.position;
		north = GameObject.Find ("NorthS").transform.position;
		south = GameObject.Find ("SouthS").transform.position;
		east = GameObject.Find ("EastS").transform.position;
		west = GameObject.Find ("WestS").transform.position;
		southEast = GameObject.Find ("SouthEastS").transform.position;
		southWest = GameObject.Find ("SouthWestS").transform.position;
		northEast = GameObject.Find ("NorthEastS").transform.position;
		northWest = GameObject.Find ("NorthWestS").transform.position;


	
	}
	
	// Update is called once per frame
	void Update () {


	
	}
}
