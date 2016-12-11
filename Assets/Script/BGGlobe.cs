using UnityEngine;
using System.Collections;

public class BGGlobe : MonoBehaviour {
	float rotatePerSec = 0.3f;
		
	// Use this for initialization
	void Start () {
	
	}

	void RotatePerFrame() {
		float rotate = Time.deltaTime * rotatePerSec;
		transform.Rotate (new Vector3(0, -rotate, 0), Space.World);
	}

	// Update is called once per frame
	void Update () {
		RotatePerFrame ();
	}
}
