using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WarpCore : MonoBehaviour {
	public Transform [] childrenTransform;
	public GameObject cube;
	public float rotationSpeed; //Rotation around core
	public int rotateDir; //Around the core -1: Left, 1: Right
	public int randomRotation; //Indivdual cube rotations
	public int randomRotationDir;
	private int[] validChoices = {-1, 1};
	public float zAxisOffset; //Random Z offset of children

	// Use this for initialization
	void Start () {
		childrenTransform = gameObject.GetComponentsInChildren<Transform>();
		CreateCubes ();
		childrenTransform = gameObject.GetComponentsInChildren<Transform>();
		rotateDir = GetRandom ();
		rotationSpeed = 0.3f;
		randomRotation = Random.Range (3, 9);
		randomRotationDir = GetRandom ();
		foreach (Transform child in childrenTransform) {
			if (child.tag == "Core Rotate") {
				zAxisOffset = Random.Range(-0.63f, 0.63f);
				child.transform.localPosition += new Vector3(0,0,zAxisOffset);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		foreach (Transform child in childrenTransform) {
			if (child.tag == "Core Rotate") {
				child.RotateAround (transform.position, Vector3.down, 90 * Time.deltaTime * (rotationSpeed * rotateDir));
				child.Rotate (randomRotation * randomRotationDir, randomRotation * randomRotationDir, randomRotation * randomRotationDir);
			}
		}
	}

	//Returns random value from validChoices array
	int GetRandom() {
		return validChoices[Random.Range(0, validChoices.Length)];
	}

	void CreateCubes() {
		int numberOfCubes = Random.Range (5, 8);
		for (int i = 0; i < numberOfCubes; i++) {
			GameObject tempCube;
			tempCube = Instantiate (cube, childrenTransform [i+1].position, childrenTransform [i+1].rotation) as GameObject;
			tempCube.transform.parent = transform;
		}
	}
}