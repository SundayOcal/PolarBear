using UnityEngine;
using System.Collections;

public class BoundaryInfo {
	public static float Height(GameObject obj) {
		Renderer rend = obj.GetComponentInChildren<Renderer>();
		if (rend) {
			return rend.bounds.size.y;
		} else {
			return obj.transform.localScale.y;
		}
	}
}
