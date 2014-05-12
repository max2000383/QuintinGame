using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public GameObject NorthSpawn;
	public GameObject SouthSpawn;
	public GameObject EastSpawn;
	public GameObject WestSpawn;
	public Transform RedObstacle;
	public Transform BlueObstacle;
	public Transform YellowObstacle;
	
	// Use this for initialization
	void Start () {
		Instantiate(RedObstacle, NorthSpawn.transform.position, Quaternion.identity);
		Instantiate(RedObstacle, SouthSpawn.transform.position, Quaternion.identity);
		Instantiate(BlueObstacle, EastSpawn.transform.position, Quaternion.identity);
		Instantiate(YellowObstacle, WestSpawn.transform.position, Quaternion.identity);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
