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
			print (Input.mousePosition);
			if (Input.mousePosition.x < Screen.width / 2) {
				GameManager.instance.BearJump ();
			} else {
				GameManager.instance.BearLongJump ();
			}
		}
	}
}
