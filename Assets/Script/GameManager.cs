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

	public void FinishGame() {
		isGameLive = false;
	}

	public void BearJump() {
		if (!isGameLive) 
			return;
		
		GameObject obj = IceburgWatcher.instance.GetNextIceburg ();
		if (obj) {
			Bear.instance.JumpOver (obj.gameObject);
			stage.MoveStep ();
		}
		if (obj.tag == "Hidden") {
			FinishGame ();
		}
	}

	public void BearLongJump() {
		if (!isGameLive) 
			return;

		GameObject obj = IceburgWatcher.instance.GetNextIceburg ();
		if (obj.tag != "Hidden") {
			FinishGame ();
			return;
		}
		Bear.instance.JumpOver (obj.gameObject);
		stage.MoveStep ();

		obj = IceburgWatcher.instance.GetNextIceburg ();
		Debug.Assert (obj.tag != "Hidden");
		Bear.instance.JumpOver (obj.gameObject);
		stage.MoveStep ();
	}
}
