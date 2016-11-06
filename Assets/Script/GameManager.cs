using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	public static GameManager instance;
	public bool isGameFinished = true;
	public bool inFinishingAction = false;
	public Stage stage;

	void Awake () {
		instance = this;
	}

	void Start () {
		isGameFinished = false;
	}
	
	// Update is called once per frame
	void Update () {

	}

	bool IsGameLive() {
		return !inFinishingAction && !isGameFinished;
	}

	IEnumerator FinishingAction() {
		inFinishingAction = true;
		yield return new WaitForSeconds (1);
		isGameFinished = true;
	}

	public void FinishGame() {
		StartCoroutine (FinishingAction());
	}

	public void RestartGame() {
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}

	public void GoHome() {
		SceneManager.LoadScene ("Home");
	}

	public void TogglePauseGame() {
		Time.timeScale = Time.timeScale == 0 ? 1 : 0;
	}

	public void BearJump() {
		if (!IsGameLive()) 
			return;
		
		GameObject obj = IceburgWatcher.instance.GetNextIceburg ();
		if (obj.tag == "Hidden") {
			FinishGame ();
		}
		if (obj) {
			Bear.instance.ReadyJump (obj);
			Bear.instance.JumpOver (obj.gameObject);

			stage.MoveStep ();
			ScoreManager.instance.AddTab ();
		}
	}

	public void BearLongJump() {
		if (!IsGameLive()) 
			return;

		GameObject obj = IceburgWatcher.instance.GetNextIceburg ();
		// get next 
		obj = IceburgWatcher.instance.GetNextIceburg ();
		if (obj.tag == "Hidden") {
			FinishGame ();
		}
		if (obj) {
			Bear.instance.ReadyJump (obj);
			Bear.instance.JumpOver (obj.gameObject);

			stage.MoveStep ();
			stage.MoveStep ();
			ScoreManager.instance.AddTab ();
		}
	}

	public void BearRun() {
		if (IsGameLive())
			return;

		Bear.instance.Run ();
	}
}
