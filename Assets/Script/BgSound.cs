using UnityEngine;
using System.Collections;

public class BgSound : MonoBehaviour {
	public static BgSound instance;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this.gameObject);
	}

	void Awake () {
		if (instance) {
			Destroy (this.gameObject);
		} else {
			instance = this;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
