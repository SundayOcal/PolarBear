using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour {
	Vector3 distanceToBear;

	// Use this for initialization
	void Start () {
		distanceToBear = Bear.instance.transform.position - transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 new_pos = Bear.instance.transform.position - distanceToBear;
		new_pos.y = transform.position.y;
		transform.position = new_pos;
	}
}
