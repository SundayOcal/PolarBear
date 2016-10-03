using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	public static LevelManager instance;
	float iceMeltTimeSec = 0;
	public float IceMeltTimeSec {
		get { return iceMeltTimeSec; }
	}
	float spawnInterval = 1;
	public float SpawnInterval {
		get { return spawnInterval; }
	}
	float iceSpawnPossibility = 1;
	public float IceSpawnPossibility {
		get { return iceSpawnPossibility; }
	}

	void Awake() {
		instance = this;
		SetLevel1 ();
	}

	void Start() {
		SetLevel1 ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void SetLevel1() {
		iceMeltTimeSec = 5;
		spawnInterval = 0.5f;
		iceSpawnPossibility = 1f;
	}
}
