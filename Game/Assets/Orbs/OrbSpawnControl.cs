﻿using UnityEngine;
using System.Collections;

public class OrbSpawnControl : MonoBehaviour {
	public GameObject orbPrefab;
	public float timer;
	public int spawnerCoolDown;
	public bool itemSpawned;
	public int itemType;

	// Use this for initialization
	void Start () {
		timer = 0.0f;
		spawnerCoolDown = 0;
		itemSpawned = false;
		itemType = 0;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (!itemSpawned) {
			spawnerCoolDown = Random.Range(3,15);
			itemType = Random.Range(0, 4); //0:Left, 1:Up, 2:Right, 3:Down
			itemSpawned = true;
			timer = 0.0f;
		}
		if (itemSpawned && timer > spawnerCoolDown) {
			switch(itemType) {
			case 0:
				GameObject redOrb = Instantiate (orbPrefab, gameObject.transform.position, gameObject.transform.rotation) as GameObject;
				redOrb.renderer.material.color = Color.red;
				itemSpawned = false;
				timer = 0.0f;
				break;
			case 1:
				GameObject greenOrb = Instantiate (orbPrefab, gameObject.transform.position, gameObject.transform.rotation) as GameObject;
				greenOrb.renderer.material.color = Color.green;
				itemSpawned = false;
				timer = 0.0f;
				break;
			case 2:
				GameObject blueOrb = Instantiate (orbPrefab, gameObject.transform.position, gameObject.transform.rotation) as GameObject;
				blueOrb.renderer.material.color = Color.blue;
				itemSpawned = false;
				timer = 0.0f;
				break;
			case 3:				
				GameObject yellowOrb = Instantiate (orbPrefab, gameObject.transform.position, gameObject.transform.rotation) as GameObject;
				yellowOrb.renderer.material.color = Color.yellow;
				itemSpawned = false;
				timer = 0.0f;
				break;

			}
		}
		if (timer > 10000.0f) {
			timer = 0.0f;
			Debug.Log("Timer Error");
		}
	}
}
