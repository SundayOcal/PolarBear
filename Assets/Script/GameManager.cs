using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public static GameManager instance;
	public bool isGameLive = false;
	public Stage stage;

	void Awake () {
		instance = this;	
	}

	void Start () {
		isGameLive = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void BearJump() {
		if (!isGameLive) 
			return;
		
		GameObject obj = IceburgWatcher.instance.GetNextIceburg ();
		if (obj) {
			Bear.instance.JumpOver (obj.gameObject);
			stage.MoveStep ();
		}
		if (!obj.GetComponent<Iceburg> ()) {
			isGameLive = false;
		}
	}

	public void BearLongJump() {
		if (!isGameLive) 
			return;

		GameObject obj = IceburgWatcher.instance.GetNextIceburg ();
		if (obj.GetComponent<Iceburg> ()) {
			isGameLive = false;
			return;
		}
		Bear.instance.JumpOver (obj.gameObject);
		stage.MoveStep ();

		obj = IceburgWatcher.instance.GetNextIceburg ();
		Bear.instance.JumpOver (obj.gameObject);
		stage.MoveStep ();
	}
}
