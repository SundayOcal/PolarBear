using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	public static LevelManager instance;
	public float IceMeltTimeSec { get; set; }
	public float IceSpawnPossibility { get; set; }
	public float FishSpawnPossibility { get; set; }
	public float FishFlyingTime { get; set; }
	public float FishFlyingInterval { get; set; }

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
		IceMeltTimeSec = 2;
		IceSpawnPossibility = 0.8f;
		FishSpawnPossibility = 0.8f;
		FishFlyingTime = 0.5f;
		FishFlyingInterval = 0.6f;
	}
}
