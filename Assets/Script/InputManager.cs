using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		print (Screen.width);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			if (Input.mousePosition.x < Screen.width / 2) {
				print (Input.mousePosition.x);
				GameManager.instance.BearJumpLeft ();
			} else {
				GameManager.instance.BearJumpRight ();
			}
		}
	}
}
