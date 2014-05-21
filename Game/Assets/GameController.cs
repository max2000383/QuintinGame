using UnityEngine;
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
	public GameObject orbRing;
	public Vector3 mousePosition;
	public GameObject Orb;
	public int currentDifficulty;
	public GameObject removedOrb;
	public GameObject OrbTopLeft;
	public GameObject OrbBotLeft;
	public GameObject OrbTopRight;
	public GameObject OrbBotRight;
	public GameObject Left;
	public GameObject Right;
	public GameObject Up;
	public GameObject Down;
	public int orbChance;
	List<int[,]> Columns=new List<int[,]>();
	List<int> ColumnDifficulty=new List<int>();
	List<int[,]> UsableObstacles=new List<int[,]>();
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
		currentDifficulty=4;//at most 4 selections are blocked at any one time.
		Left = GameObject.Find ("InnerWestSpawner");
		Right = GameObject.Find ("InnerEastSpawner");
		Up = GameObject.Find ("InnerNorthSpawner");
		Down = GameObject.Find ("InnerSouthSpawner");
		Home = GameObject.Find ("InnerCenterSpawner");
		int j;
		orbChance=5;
		GenerateObstacles();//generates all possible obstacles.
		//Debug.Log (ObstacleSource[1,1]);
		for(j=0;j<200;j++){
			for(int k=0;k<8;k++)ObstacleSource[j,k]=Random.Range(0,2);
			startTime=Time.time;
		}
		for(j=0;j<8;j++){
			generateNewLine();
		}
		StartCoroutine("Example");

	}
	IEnumerator Example() {
		Debug.Log(Time.time);
		yield return new WaitForSeconds(0.2f);
		Debug.Log(Time.time);
	}

	void generateNewLine(){ //generates a new line based on the current difficulty, etc.

		for(int j=0;j<7;j++)for(int k=0;k<13;k++)newObstacle[j,k]=newObstacle[j+1,k];//moves everything up.

		//for(int k=0;k<7;k++)newObstacle[0,k]=Random.Range(-1,5); //generic test thing goes here.
		//change this seven to a  thirteen to reeenable middle spawning stuff
		//zipp is a wuss
		//so, you basically generate these things eight times in advance.

		//check here for past "make this in three lines" things.

		// -1 means not an orb -2 means not a obstacle.
		//0 means has nothing
		//1 means red
		//2 means blue
		//3 means 

		//code goes here to make a new last line.
		while(totalDiff(0)<4){
			//generate and or use a list of usable difficulty things here. still need to make a "passable" check.
			foreach (int[,] obstacle in Columns){
				//this takes in each possible obstacle presently and checks them for validity. all good ones are added to passable obstacles.
				if(isGood(obstacle))UsableObstacles.Add(obstacle);

			}
			//now usableobstacles is full of potential obstacles. pick one at random and add it!
			int theIndex=Random.Range (0,UsableObstacles.Count);
			addObstacle(UsableObstacles[theIndex]);

		}
		//orb generation here.
		for(int j=0;j<13;j++){
			if(Random.Range(0,orbChance)==0&&newObstacle[1,j]==0)newObstacle[1,j]=4;
			if(Random.Range(0,3)==0&&newObstacle[0,j]==4)newObstacle[1,j]=4;

		}


	}
	void addObstacle(int[,] addMe){
		int col=Random.Range(1,4);
		for(int i=0;i<8;i++){
			for(int j=0;j<13;j++){
				if(addMe[i,j]!=0){
					//Debug.Log ("added one");
					//newObstacle[i,j]=addMe[i,j];
					newObstacle[i,j]=col;
				}

			}

		}
		//Debug.Log ("Next Line: "+totalDiff (1));

	}
	bool isGood(int[,] compare){

		return true;
	}
	int totalDiff(int line){
		//goes to given line and sums the difficulty, meaning adding anything not an orb.
		int dCount=0;//assuming that we have three obstacles and orbs start at four.
		for(int i=0;i<13;i++)if(newObstacle[line,i]>0&&newObstacle[line,i]<4)dCount++;
		return dCount;

	}
	// Update is called once per frame
	void Update () {

		//mousePosition=Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,5f));
		if(true)if(checkAll())updateAll();
		if(checkClicked()>0)removeClick(checkClicked());
		counter+=Time.deltaTime;
		if(counter>=ObstacleFrequency){
			counter=0;
			//for(int k=0;k<13;k++)Debug.Log (newObstacle[0,k]);
			for(int i=0;i<13;i++){

				if(newObstacle[0,i]>0)SpawnObstacle(i+1,newObstacle[0,i]);

			}
			generateNewLine();
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
			//spawnPosition=Home.transform.position;
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
		case 6:
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
		case 5://this should be the kooky multiple orb thing.
		case 4://SHOULD NEVER BE CALLED
			Spawned = Instantiate(orbRing, spawnPosition, Quaternion.identity) as GameObject;
			Spawned.GetComponent<RingCollect>().startup();
//			Debug.Log (Spawned.GetComponent<RingCollect>().getOrbs().Count);
			foreach (Component location in Spawned.GetComponent<RingCollect>().getScripts()){
				//Debug.Log(orb.GetComponent<RingOrbInstantiate>().getColorRef());
				spawnPosition=location.gameObject.transform.position;
				GameObject childSpawned = Instantiate(Orb, spawnPosition, Quaternion.identity) as GameObject;
				switch(decideColor()){
					case 0:

					childSpawned.renderer.material.color=Color.red;
					redOrbs.Add (childSpawned);
					break;
				case 1:
					childSpawned.renderer.material.color=Color.blue;
					blueOrbs.Add (childSpawned);
					break;
				case 2:
					childSpawned.renderer.material.color=Color.green;
					greenOrbs.Add (childSpawned);
					break;
				case 3:
					childSpawned.renderer.material.color=Color.yellow;
					yellowOrbs.Add (childSpawned);
					break;

				}
			}
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
		if(redOrbs.Count>0)foreach (GameObject orb in redOrbs){
			if(orb.GetComponent<OrbControllerMax>().Clicked()){
				return 5;
			}
		}
		if(blueOrbs.Count>0)foreach (GameObject orb in blueOrbs){
			if(orb.GetComponent<OrbControllerMax>().Clicked()){
				return 6;
			}
		}
		if(yellowOrbs.Count>0)foreach (GameObject orb in yellowOrbs){
			if(orb.GetComponent<OrbControllerMax>().Clicked()){
				return 7;
			}
		}
		if(greenOrbs.Count>0)foreach (GameObject orb in greenOrbs){
			if(orb.GetComponent<OrbControllerMax>().Clicked()){
				return 8;
			}
		}
		return 0;
	}

	public void removeClick(int color){
		bool removeFlag=false;
		switch(color){
			case 1:
				foreach(GameObject orb in redOrbs){
					if(orb.GetComponent<OrbControllerMax>().Clicked()){//actual let go with acceptable velocity
						removedOrb=Orb;//remove it from orbs later.
						removedOrb.GetComponent<OrbControllerMax>().isProcessed(Home.transform.position);

					}
				}
				foreach(GameObject orb in CollectedRedOrbs){
					if(CollectedRedOrbs.Contains(orb)&&orb.GetComponent<OrbControllerMax>().isClicked()){
						removedOrb=orb;
					}
				}
				if(removedOrb.GetComponent<OrbControllerMax>().Clicked()){
					removeFlag=true;
					redOrbs.Remove(removedOrb);
				}
				else CollectedRedOrbs.Remove(removedOrb);
				updateRed();
				break;
			case 2:
				foreach(GameObject orb in CollectedBlueOrbs){
					if(CollectedBlueOrbs.Contains(orb)&&orb.GetComponent<OrbControllerMax>().isClicked()){
						removedOrb=orb;
						
					}
				}
				if(removedOrb.GetComponent<OrbControllerMax>().Clicked()){
					removeFlag=true;
					redOrbs.Remove(removedOrb);
				}
				CollectedBlueOrbs.Remove(removedOrb);
				
				updateBlue();
				break;
			case 3:
				foreach(GameObject orb in CollectedYellowOrbs){
					if(CollectedYellowOrbs.Contains(orb)&&orb.GetComponent<OrbControllerMax>().isClicked()){
						removedOrb=orb;
						
					}
				}
				if(removedOrb.GetComponent<OrbControllerMax>().Clicked()){
					removeFlag=true;
					yellowOrbs.Remove(removedOrb);
				}
				CollectedYellowOrbs.Remove(removedOrb);
				
				updateYellow();
				break;
			case 4:
				foreach(GameObject orb in CollectedGreenOrbs){
					if(CollectedGreenOrbs.Contains(orb)&&orb.GetComponent<OrbControllerMax>().isClicked()){
						removedOrb=orb;
						
					}
				}
				if(removedOrb.GetComponent<OrbControllerMax>().Clicked()){
					removeFlag=true;
					greenOrbs.Remove(removedOrb);
				}
				CollectedGreenOrbs.Remove(removedOrb);
				updateGreen();
				break;
		case 5:
			foreach(GameObject orb in redOrbs){
				if (orb.GetComponent<OrbControllerMax>().Clicked())removedOrb=orb;

			}
			redOrbs.Remove(removedOrb);
			removedOrb.GetComponent<OrbControllerMax>().isProcessed(Home.transform.position);
			break;
		case 6:
			foreach(GameObject orb in blueOrbs){
				if (orb.GetComponent<OrbControllerMax>().Clicked())removedOrb=orb;
				
			}
			blueOrbs.Remove(removedOrb);
			removedOrb.GetComponent<OrbControllerMax>().isProcessed(Home.transform.position);
			break;
		case 7:
			foreach(GameObject orb in yellowOrbs){
				if (orb.GetComponent<OrbControllerMax>().Clicked())removedOrb=orb;
				
			}
			yellowOrbs.Remove(removedOrb);
			removedOrb.GetComponent<OrbControllerMax>().isProcessed(Home.transform.position);
			break;
		case 8:
			foreach(GameObject orb in greenOrbs){
				if (orb.GetComponent<OrbControllerMax>().Clicked())removedOrb=orb;
				
			}
			greenOrbs.Remove(removedOrb);
			removedOrb.GetComponent<OrbControllerMax>().isProcessed(Home.transform.position);
			break;


		}
		//if(true)removedOrb.GetComponent<OrbControllerMax>().isProcessed(Home.transform.position);
		

	}
	public bool checkAll(){
		if(redOrbs.Count>0)foreach (GameObject orb in redOrbs){
//			Debug.Log(orb.GetComponent<OrbControllerMax>().isCollected());
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
			//if(orb.GetComponent<OrbControllerMax>().isClicked())CollectedRedOrbs.Remove(orb);
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
	void GenerateObstacles(){
		for(int i=0;i<13;i++){
			for(int j=4;j<8;j++){
				int[,] tempArray=new int[8,13];
				//so here you have a nested for loop that makes all possible columns, made of whatever material.
				//a total value lookup would be really sweet, actually. tie difficulty straight to how big the things are you're trying to squeeze in.
				for(int k=0;k<j;k++){
					tempArray[k,i]=1;
				}
				Columns.Add(tempArray);
				ColumnDifficulty.Add(j);

			}

		}
		
	}
}
