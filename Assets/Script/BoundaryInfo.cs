using UnityEngine;
using System.Collections;

public class BoundaryInfo {
	public static float Height(GameObject obj) {
		BoxCollider collider = obj.GetComponent<BoxCollider> ();
		if (collider) {
			return obj.GetComponent<BoxCollider> ().size.y * obj.transform.localScale.y;
		} else {
			return obj.transform.localScale.y;
		}
	}
}
