﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {
	public GameObject NorthSpawn;
	public GameObject NorthEastSpawn;
	public GameObject Home;
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
	public GameObject removedOrb;
	public GameObject OrbTopLeft;
	public GameObject OrbBotLeft;
	public GameObject OrbTopRight;
	public GameObject OrbBotRight;
	public GameObject Left;
	public GameObject Right;
	public GameObject Up;
	public GameObject Down;
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
	public int[,] newObstacle=new int[8,13];
	public float ObstacleFrequency;
	public int ObstacleNumber=0;
	public float counter=0;
	public float testOne;
	float startTime;

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
		startTime=Time.time;
		Left = GameObject.Find ("InnerWestSpawner");
		Right = GameObject.Find ("InnerEastSpawner");
		Up = GameObject.Find ("InnerNorthSpawner");
		Down = GameObject.Find ("InnerSouthSpawner");
		Home = GameObject.Find ("InnerCenterSpawner");
		int j;
		//Debug.Log (ObstacleSource[1,1]);
		for(j=0;j<200;j++){
			for(int k=0;k<8;k++)ObstacleSource[j,k]=Random.Range(0,2);
			startTime=Time.time;
		}
		for(j=0;j<8;j++){
			generateNewLine();
		}

	}
	void AddOrb(GameObject theOrb){
		//adds an orb to the array of distributed orbs.

	}
	void generateNewLine(){ //generates a new line based on the current difficulty, etc.

		for(int j=0;j<7;j++)for(int k=0;k<13;k++)newObstacle[j,k]=newObstacle[j+1,k];//moves everything up.

		for(int k=0;k<13;k++)newObstacle[0,k]=Random.Range(-2,2); //generic test thing goes here.
		//so, you basically generate these things eight times in advance.

		//check here for past "make this in three lines" things.

		// -1 means not an orb -2 means not a obstacle.
		//0 means has nothing
		//1 means red
		//2 means blue
		//3 means 

		//code goes here to make a new last line.


	}
	// Update is called once per frame
	void Update () {
		if(true)if(checkAll())updateAll();
		if(checkClicked()>0)removeClick(checkClicked());
		counter+=Time.deltaTime;
		if(counter>=ObstacleFrequency){
			counter=0;
			for(int k=0;k<13;k++)Debug.Log (newObstacle[0,k]);
			for(int i=0;i<13;i++)if(newObstacle[0,i]>0)SpawnObstacle(i+1,Random.Range(1,5));
			generateNewLine ();
		}
		/*
		if(counter>=ObstacleFrequency){
			counter=0;
			//Debug.Log(Random.Range (0,2));
			for(int i=0;i<=7;i++){
				if(ObstacleSource[ObstacleNumber,i]==1)SpawnObstacle(i+1,Random.Range(1,4));
			}
				ObstacleNumber++;
			
			
		}
		*/

	}
	void SpawnObstacle(int position,int type){
		Transform toSpawn;


		Vector3 spawnPosition=ObstacleSpawnLocation.transform.position;
		//Debug.Log("SpawnEnemy");
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
		//1-8 are the outside ones, 9-13 are the internal ones
		case 9:
			spawnPosition=Home.transform.position;
			break;
		case 10:
			spawnPosition=Up.transform.position;
			break;
		case 11:
			spawnPosition=Down.transform.position;
			break;
		case 12:
			spawnPosition=Left.transform.position;
			break;
		case 13:
			spawnPosition=Right.transform.position;
			break;
		}
		GameObject Spawned;
		switch (type)
		{
		case 1:
			//toSpawn=RedObstacle;
			Spawned = Instantiate(RedObstacle, spawnPosition, Quaternion.identity) as GameObject;
			break;
		case 2:
			//toSpawn=BlueObstacle;
			Spawned = Instantiate(BlueObstacle, spawnPosition, Quaternion.identity) as GameObject;
			break;
		case 4:
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
		case 3:
			//toSpawn=BlueObstacle;
			Spawned = Instantiate(YellowObstacle, spawnPosition, Quaternion.identity) as GameObject;
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
	public int checkClicked(){

		if(CollectedRedOrbs.Count>0)foreach (GameObject orb in CollectedRedOrbs){
			if(CollectedRedOrbs.Contains(orb)&&orb.GetComponent<OrbControllerMax>().isClicked()){
				return 1;
			}
		}
		if(CollectedBlueOrbs.Count>0)foreach (GameObject orb in CollectedBlueOrbs){
			if(CollectedBlueOrbs.Contains(orb)&&orb.GetComponent<OrbControllerMax>().isClicked()){
				return 2;
			}
		}
		if(CollectedYellowOrbs.Count>0)foreach (GameObject orb in CollectedYellowOrbs){
			if(CollectedYellowOrbs.Contains(orb)&&orb.GetComponent<OrbControllerMax>().isClicked()){
				return 3;
			}
		}
		if(CollectedGreenOrbs.Count>0)foreach (GameObject orb in CollectedGreenOrbs){
			if(CollectedGreenOrbs.Contains(orb)&&orb.GetComponent<OrbControllerMax>().isClicked()){
				return 4;
			}
		}
		return 0;
	}
	public void removeClick(int color){
		switch(color){
			case 1:
				foreach(GameObject orb in CollectedRedOrbs){
				if(CollectedRedOrbs.Contains(orb)&&orb.GetComponent<OrbControllerMax>().isClicked()){
					removedOrb=orb;

					}
				}
				removedOrb.GetComponent<OrbControllerMax>().isProcessed(Home.transform.position);
				CollectedRedOrbs.Remove(removedOrb);
				redOrbs.Remove(removedOrb);
				updateRed();
				break;
			case 2:
				foreach(GameObject orb in CollectedBlueOrbs){
					if(CollectedBlueOrbs.Contains(orb)&&orb.GetComponent<OrbControllerMax>().isClicked()){
						removedOrb=orb;
						
					}
				}
				removedOrb.GetComponent<OrbControllerMax>().isProcessed(Home.transform.position);
				CollectedBlueOrbs.Remove(removedOrb);
				blueOrbs.Remove(removedOrb);
				updateBlue();
				break;
			case 3:
				foreach(GameObject orb in CollectedYellowOrbs){
					if(CollectedYellowOrbs.Contains(orb)&&orb.GetComponent<OrbControllerMax>().isClicked()){
						removedOrb=orb;
						
					}
				}
				removedOrb.GetComponent<OrbControllerMax>().isProcessed(Home.transform.position);
				CollectedYellowOrbs.Remove(removedOrb);
				yellowOrbs.Remove(removedOrb);
				updateYellow();
				break;
			case 4:
				foreach(GameObject orb in CollectedGreenOrbs){
					if(CollectedGreenOrbs.Contains(orb)&&orb.GetComponent<OrbControllerMax>().isClicked()){
						removedOrb=orb;
						
					}
				}
			removedOrb.GetComponent<OrbControllerMax>().isProcessed(Home.transform.position);
				CollectedGreenOrbs.Remove(removedOrb);
				greenOrbs.Remove(removedOrb);
				updateGreen();
				break;

		}

	}
	public bool checkAll(){
		if(redOrbs.Count>0)foreach (GameObject orb in redOrbs){
			if(!CollectedRedOrbs.Contains(orb)&&orb.GetComponent<OrbControllerMax>().isCollected()){
				return true;
			}
		}
		if(blueOrbs.Count>0)foreach (GameObject orb in blueOrbs){
			if(!CollectedBlueOrbs.Contains(orb)&&orb.GetComponent<OrbControllerMax>().isCollected()){
				return true;
			}
		}
		if(yellowOrbs.Count>0)foreach (GameObject orb in yellowOrbs){
			if(!CollectedYellowOrbs.Contains(orb)&&orb.GetComponent<OrbControllerMax>().isCollected()){
				return true;
			}
		}
		if(greenOrbs.Count>0)foreach (GameObject orb in greenOrbs){
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
			//Debug.Log (count+" "+CollectedRedOrbs.Count);
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
