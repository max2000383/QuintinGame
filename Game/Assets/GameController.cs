using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public GameObject NorthSpawn;
	public GameObject NorthEastSpawn;
	public GameObject NorthWestSpawn;
	public GameObject SouthSpawn;
	public GameObject SouthEastSpawn;
	public GameObject SouthWestSpawn;
	public GameObject EastSpawn;
	public GameObject WestSpawn;
	public Transform RedObstacle;
	public Transform BlueObstacle;
	public Transform YellowObstacle;
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
		Debug.Log("SpawnEnemy");
		switch (type)
		{
		case 1:
			toSpawn=RedObstacle;
			break;
		case 2:
			toSpawn=BlueObstacle;
			break;
		case 3:
			toSpawn=YellowObstacle;
			break;
		default:
			toSpawn=RedObstacle;
			break;
		}
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
	}
}
