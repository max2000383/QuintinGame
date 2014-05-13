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
	List<GameObject> blueOrbs = new List<GameObject>();
	public List<GameObject> CollectedBlueOrbs = new List<GameObject>();
	List<GameObject> yellowOrbs = new List<GameObject>();
	public List<GameObject> CollectedYellowOrbs = new List<GameObject>();
	List<GameObject> greenOrbs = new List<GameObject>();
	public List<GameObject> CollectedGreenOrbs = new List<GameObject>();
	//public GameObject Spawned;
	public int[,] ObstacleSource=new int[200,8];
	public float ObstacleFrequency;
	public int ObstacleNumber=0;
	public float counter=0;
	public float testOne;
	public int testTwo;
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
		if(checkAll())updateAll();
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
					//orbb.GetComponent<OrbControllerMax>().setInitialDestination(Vector3.Lerp(OrbTopLeft.transform.position,OrbTopRight.transform.position,0.5f));
					blueOrbs.Add(orbb);
					//updateBlue();
					break;
				case 0:
					setColor=Color.red;
					//orbb.GetComponent<OrbControllerMax>().setInitialDestination(Vector3.Lerp(OrbTopLeft.transform.position,OrbBotLeft.transform.position,0.5f));
					redOrbs.Add(orbb);
					//updateRed();
					break;
				case 2:
					setColor=Color.yellow;
					//orbb.GetComponent<OrbControllerMax>().setInitialDestination(Vector3.Lerp(OrbTopRight.transform.position,OrbBotRight.transform.position,0.5f));
					yellowOrbs.Add(orbb);
					//updateYellow();
					break;
				case 3:
					setColor=Color.green;
					//orbb.GetComponent<OrbControllerMax>().setInitialDestination(Vector3.Lerp(OrbBotRight.transform.position,OrbBotLeft.transform.position,0.5f));
					greenOrbs.Add(orbb);
					//updateGreen();
					break;
				
				
			}
			orbb.renderer.material.color = setColor;

			break;
		default:
			//toSpawn=RedObstacle;
			Spawned = Instantiate(RedObstacle, spawnPosition, Quaternion.identity) as GameObject;
			break;
		}
		/*
		updateRed();
		updateBlue();
		updateYellow();
		updateGreen();
		*/
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
	public bool checkAll(){
		foreach (GameObject orb in redOrbs){
			if(!CollectedRedOrbs.Contains(orb)&&orb.GetComponent<OrbControllerMax>().isCollected()){
				return true;
			}
		}
		foreach (GameObject orb in blueOrbs){
			if(!CollectedBlueOrbs.Contains(orb)&&orb.GetComponent<OrbControllerMax>().isCollected()){
				return true;
			}
		}
		foreach (GameObject orb in yellowOrbs){
			if(!CollectedYellowOrbs.Contains(orb)&&orb.GetComponent<OrbControllerMax>().isCollected()){
				return true;
			}
		}
		foreach (GameObject orb in greenOrbs){
			if(!CollectedGreenOrbs.Contains(orb)&&orb.GetComponent<OrbControllerMax>().isCollected()){
				return true;
			}
		}
		return false;

	}
	public void updateAll(){
		updateRed();
		updateBlue();
		updateYellow();
		updateGreen();
	}
	int decideColor(){
		return Random.Range (0,4);
		//return 3;
		
	}
	void updateRed(){
		float count=0;
		foreach (GameObject orb in redOrbs){
			if(!CollectedRedOrbs.Contains(orb)&&orb.GetComponent<OrbControllerMax>().isCollected()){
				if(CollectedRedOrbs.Count<3)CollectedRedOrbs.Add(orb);
				else CollectedRedOrbs.Insert(CollectedRedOrbs.Count/2,orb);
			}
		}
		foreach (GameObject orb in CollectedRedOrbs){
			count++;
			Debug.Log (count+" "+CollectedRedOrbs.Count);
			orb.GetComponent<OrbControllerMax>().setDestination(Vector3.Lerp(OrbTopLeft.transform.position,OrbBotLeft.transform.position,count/(CollectedRedOrbs.Count+1)));
			//orb.transform.position=Vector3.Lerp(OrbBotLeft.transform.position,OrbTopLeft.transform.position,count/CollectedRedOrbs.Count);
		}
	}
	void updateBlue(){
		float count=0;
		foreach (GameObject orb in blueOrbs){
			if(!CollectedBlueOrbs.Contains(orb)&&orb.GetComponent<OrbControllerMax>().isCollected()){
				if(CollectedBlueOrbs.Count<3&&false)CollectedBlueOrbs.Add(orb);
				else CollectedBlueOrbs.Insert(CollectedBlueOrbs.Count/2,orb);
			}
		}
		foreach (GameObject orb in CollectedBlueOrbs){
			count++;
			testOne=count;
			testTwo=redOrbs.Count;
			orb.GetComponent<OrbControllerMax>().setDestination(Vector3.Lerp(OrbTopRight.transform.position,OrbTopLeft.transform.position,count/(CollectedBlueOrbs.Count+1)));
			//orb.transform.position=Vector3.Lerp(OrbBotLeft.transform.position,OrbTopLeft.transform.position,count/CollectedBlueOrbs.Count);
		}
	}
	void updateYellow(){
		float count=0;
		foreach (GameObject orb in yellowOrbs){
			if(!CollectedYellowOrbs.Contains(orb)&&orb.GetComponent<OrbControllerMax>().isCollected()){
				if(CollectedYellowOrbs.Count<3)CollectedYellowOrbs.Add(orb);
				else CollectedYellowOrbs.Insert(CollectedYellowOrbs.Count/2,orb);
			}
		}
		foreach (GameObject orb in CollectedYellowOrbs){
			count++;
			testOne=count;
			testTwo=redOrbs.Count;
			orb.GetComponent<OrbControllerMax>().setDestination(Vector3.Lerp(OrbBotRight.transform.position,OrbTopRight.transform.position,count/(CollectedYellowOrbs.Count+1)));
			//orb.transform.position=Vector3.Lerp(OrbBotLeft.transform.position,OrbTopLeft.transform.position,count/CollectedYellowOrbs.Count);
		}
	}
	void updateGreen(){
		float count=0;
		foreach (GameObject orb in greenOrbs){
			if(!CollectedGreenOrbs.Contains(orb)&&orb.GetComponent<OrbControllerMax>().isCollected()){
				if(CollectedGreenOrbs.Count<3)CollectedGreenOrbs.Add(orb);
				else CollectedGreenOrbs.Insert(CollectedGreenOrbs.Count/2,orb);
			}
		}
		foreach (GameObject orb in CollectedGreenOrbs){
			count++;
			testOne=count;
			testTwo=redOrbs.Count;
			orb.GetComponent<OrbControllerMax>().setDestination(Vector3.Lerp(OrbBotLeft.transform.position,OrbBotRight.transform.position,count/(CollectedGreenOrbs.Count+1)));
			//orb.transform.position=Vector3.Lerp(OrbBotLeft.transform.position,OrbTopLeft.transform.position,count/CollectedGreenOrbs.Count);
		}
	}	
}
