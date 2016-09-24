using UnityEngine;
using System.Collections;

public class BGGlobe : MonoBehaviour {
	public GameObject iceburgMock;
	float rotatePerSec = 0.1f;
		
	// Use this for initialization
	void Start () {
	
	}

	void RotatePerFrame() {
		float iceburgMove = iceburgMock.GetComponent<Iceburg> ().MoveMeterPerSec ();
		float rotate = Time.deltaTime * iceburgMove * rotatePerSec;
		transform.Rotate (new Vector3(0, -rotate, 0), Space.World);
	}

	// Update is called once per frame
	void Update () {
		RotatePerFrame ();
	}
}
