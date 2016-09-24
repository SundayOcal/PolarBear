﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class IceburgSpawner : MonoBehaviour {
	public static IceburgSpawner instance;
	public GameObject iceburgMock;
	public GameObject emptyIceburgMock;
	float spawnDistance = 5;
	float spawnZRange = 8;
	public float SpawnDistance {
		get { return spawnDistance; }
	}
	float timeDelta = 0;
	bool spawnSkipped = false;
	float spawnYpos;

	public GameObject SpawnIce() {
		return TryCreateNewIce ();
	}

	void Awake() {
		instance = this;
	}

	void Start () {
		spawnYpos = transform.position.y;

		Vector3 tmp = transform.position;
		tmp.x = Bear.instance.transform.position.x + spawnDistance;
		transform.position = tmp;

		SpawnInitialIce ();
	}

	void SpawnInitialIce() {
		TryCreateNewIce ();
		foreach( int _ in Enumerable.Range( 0, 7 ) ) {
			transform.position += new Vector3(spawnDistance, 0, 0);
			TryCreateNewIce ();
		}
	}

	GameObject CreateNewIce() {
		float zFix = Random.Range (-spawnZRange / 2 , spawnZRange / 2);

		GameObject newIce = 
			(GameObject)Instantiate(iceburgMock, 
				new Vector3(transform.position.x, spawnYpos, transform.position.z + zFix),
				Quaternion.identity);
		return newIce;
	}

	GameObject CreateEmptyIce() {
		GameObject emptyIce = 
			(GameObject)Instantiate(emptyIceburgMock, 
				new Vector3(transform.position.x, spawnYpos, transform.position.z),
				Quaternion.identity);
		return emptyIce;
	}

	GameObject TryCreateNewIce() {
		GameObject newIceburg;
		if (spawnSkipped ||
			Random.Range (0.0f, 1.0f) <= LevelManager.instance.IceSpawnPossibility) {
			spawnSkipped = false;
			newIceburg = CreateNewIce ();
		} else {
			spawnSkipped = true;
			newIceburg = CreateEmptyIce ();
		}

		IceburgWatcher.instance.WatchIceburg (newIceburg);
		return newIceburg;
	}
	/*
	void CreateNewIcePerFrame() {
		timeDelta += Time.deltaTime;
		if (timeDelta >= LevelManager.instance.SpawnInterval) {
			TryCreateNewIce ();
			timeDelta = 0;
		}
	}*/
	
	// Update is called once per frame
	void Update () {
		
	}
}