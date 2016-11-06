using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {
	public static ScoreManager instance;
	public int Score {
		get { return score; }
	}
	public int Best {
		get { return best; }
	}

	int score = 0;
	static int best = 0;

	public void AddTab() {
		score += 1;
		if (best < score) {
			best = score;
		}
	}

	public void Save () {
		PlayerPrefs.SetInt ("best", best);
	}

	void Awake() {
		instance = this;
	}

	void Start () {
		score = 0;
		best = PlayerPrefs.GetInt ("best");
	}
}
