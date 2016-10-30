using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour {
	Text score;
	Text best;
	GameObject panGameOver;

	public void OnBtnRestart() {
		print ("restart");
		GameManager.instance.RestartGame ();
	}

	public void OnBtnPause() {
		GameManager.instance.TogglePauseGame ();
	}

	public void OnBtnLeft() {
		GameManager.instance.BearLongJump ();
	}

	public void OnBtnRight() {
		GameManager.instance.BearJump ();
	}

	void Awake () {
		score = transform.FindChild ("imgScore/Text").GetComponent<Text>();
		best = transform.FindChild ("imgBest/Text").GetComponent<Text>();
		panGameOver = transform.FindChild ("panGameOver").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		score.text = ScoreManager.instance.Score.ToString ();
		best.text = ScoreManager.instance.Best.ToString ();

		if (GameManager.instance.isGameFinished) {
			panGameOver.SetActive (true);
		}
	}
		
}
