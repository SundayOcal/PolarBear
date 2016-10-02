using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

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

	public void RestartGame() {
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}

	public void BearJumpLeft() {
		if (!isGameLive) 
			return;
		
		GameObject obj = IceburgWatcher.instance.GetNextIceburg ();
		if (obj.tag != "left") {
			FinishGame ();
			return;
		}
		if (obj.tag == "Hidden") {
			FinishGame ();
			return;
		}

		if (obj) {
			Bear.instance.JumpOver (obj.gameObject);
			stage.MoveStep ();
			ScoreManager.instance.AddTab ();
		}
	}

	public void BearJumpRight() {
		if (!isGameLive)
			return;

		GameObject obj = IceburgWatcher.instance.GetNextIceburg ();
		if (obj.tag != "right") {
			FinishGame ();
			return;
		}
		if (obj.tag == "Hidden") {
			FinishGame ();
			return;
		}

		if (obj) {
			Bear.instance.JumpOver (obj.gameObject);
			stage.MoveStep ();
			ScoreManager.instance.AddTab ();
		}
	}
}
