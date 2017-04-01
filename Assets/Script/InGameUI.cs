using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour {
	Text score;
	Text best;
	GameObject panGameOver;
	GameObject panHelp;

	public void OnBtnRestart() {
		print ("restart");
		GameManager.instance.RestartGame ();
	}

	public void OnBtnHome() {
		print ("Home");
		GameManager.instance.GoHome ();
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

	public void OnPanHelpClose() {
		panHelp.SetActive (false);
		OnBtnPause ();
	}

	public void OnPanHelpOpen() {
		panHelp.SetActive (true);
		OnBtnPause ();
	}

	void Awake () {
		score = transform.FindChild ("imgScore/Text").GetComponent<Text>();
		best = transform.FindChild ("imgBest/Text").GetComponent<Text>();
		panGameOver = transform.FindChild ("panGameOver").gameObject;
		panHelp = transform.FindChild ("panHelp").gameObject;
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
