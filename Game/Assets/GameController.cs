using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {
	public GameObject NorthSpawn;
	public GameObject NorthEastSpawn;
	public GameObject NorthWestSpawn;
	public GameObject SouthSpawn;
	public GameObject SouthEastSpawn;
	public GameObject SouthWestSpawn;
	public GameObject EastSpawn;
	public GameObject WestSpawn;
	public GameObject ObstacleSpawnLocation;
	public GameObject RedObstacle;
	public GameObject BlueObstacle;
	public GameObject YellowObstacle;
	public GameObject Orb;
	public GameObject OrbTopLeft;
	public GameObject OrbBotLeft;
	public GameObject OrbTopRight;
	public GameObject OrbBotRight;
	List<GameObject> redOrbs = new List<GameObject>();
	public List<GameObject> CollectedRedOrbs = new List<GameObject>();
	//public GameObject Spawned;
	public int[,] ObstacleSource=new int[200,8];
	public float ObstacleFrequency;
	public int ObstacleNumber=0;
	public float counter=0;
	// Use this for initialization
	void Start () {
		/*
		Instantiate(RedObstacle, NorthSpawn.transform.position, Quaternion.identity);
		Instantiate(RedObstacle, SouthSpawn.transform.position, Quaternion.identity);
		Instantiate(BlueObstacle, EastSpawn.transform.position, Quaternion.identity);
		Instantiate(YellowObstacle, WestSpawn.transform.position, Quaternion.identity);
		*/
		ObstacleFrequency=1.5f;
		for(int j=0;j<200;j++){
			for(int k=0;k<8;k++)ObstacleSource[j,k]=Random.Range(0,2);

		}
	}
	void AddOrb(GameObject theOrb){
		//adds an orb to the array of distributed orbs.

	}
	// Update is called once per frame
	void Update () {
		counter+=Time.deltaTime;
		if(counter>=ObstacleFrequency){
			counter=0;
			//Debug.Log(Random.Range (0,2));
			for(int i=0;i<=7;i++){
				if(ObstacleSource[ObstacleNumber,i]==1)SpawnObstacle(i+1,Random.Range(1,4));
			}
				ObstacleNumber++;
			
			
		}

	}
	void SpawnObstacle(int position,int type){
		Transform toSpawn;

		Vector3 spawnPosition=ObstacleSpawnLocation.transform.position;
		Debug.Log("SpawnEnemy");
		switch(position){
		case 1:
			spawnPosition=NorthSpawn.transform.position;

			break;
		case 2:
			spawnPosition=NorthEastSpawn.transform.position;
			//Spawned.transform.position=test;
			break;
		case 3:
			spawnPosition=EastSpawn.transform.position;
			break;
		case 4:
			spawnPosition=SouthEastSpawn.transform.position;
			break;
		case 5:
			spawnPosition=SouthSpawn.transform.position;
			break;
		case 6:
			spawnPosition=SouthWestSpawn.transform.position;
			break;
		case 7:
			spawnPosition=WestSpawn.transform.position;
			break;
		case 8:
			spawnPosition=NorthWestSpawn.transform.position;
			break;
		}
		switch (type)
		{
		case 1:
			//toSpawn=RedObstacle;
			GameObject Spawned = Instantiate(RedObstacle, spawnPosition, Quaternion.identity) as GameObject;
			break;
		case 2:
			//toSpawn=BlueObstacle;
			Spawned = Instantiate(BlueObstacle, spawnPosition, Quaternion.identity) as GameObject;
			break;
		case 3:
			GameObject orbb = Instantiate(Orb, spawnPosition, Quaternion.identity) as GameObject;
			int c=decideColor();
			Color setColor=Color.blue;
			switch(c){
				case 1:
					setColor=Color.blue;
					break;
				case 0:
					setColor=Color.red;
					redOrbs.Add(orbb);
					updateRed();
					break;


			}
			orbb.renderer.material.color = setColor;

			break;
		default:
			//toSpawn=RedObstacle;
			Spawned = Instantiate(RedObstacle, spawnPosition, Quaternion.identity) as GameObject;
			break;
		}
		Vector3 test;

		/*
		switch(position){
			case 1:
				Instantiate(toSpawn, NorthSpawn.transform.position, Quaternion.identity);
				break;
			case 2:
				Instantiate(toSpawn, NorthEastSpawn.transform.position, Quaternion.identity);
				break;
			case 3:
				Instantiate(toSpawn, EastSpawn.transform.position, Quaternion.identity);
				break;
			case 4:
				Instantiate(toSpawn, SouthEastSpawn.transform.position, Quaternion.identity);
				break;
			case 5:
				Instantiate(toSpawn, SouthSpawn.transform.position, Quaternion.identity);
				break;
			case 6:
				Instantiate(toSpawn, SouthWestSpawn.transform.position, Quaternion.identity);
				break;
			case 7:
				Instantiate(toSpawn, WestSpawn.transform.position, Quaternion.identity);
				break;
			case 8:
				Instantiate(toSpawn, NorthWestSpawn.transform.position, Quaternion.identity);
				break;
		}
		*/ 
	}
	int decideColor(){
		return 0;
		
	}
	void updateRed(){
		int count=0;
		foreach (GameObject orb in redOrbs){
			if(!CollectedRedOrbs.Contains(orb)&&orb.GetComponent<OrbControllerMax>().isCollected())CollectedRedOrbs.Add(orb);
		}
		foreach (GameObject orb in CollectedRedOrbs){
			count++;
			orb.transform.position=Vector3.Lerp(OrbBotLeft.transform.position,OrbTopLeft.transform.position,count/redOrbs.Count);

		}
	}	
}
