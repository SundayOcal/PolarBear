using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class IceburgWatcher : MonoBehaviour {
	public static IceburgWatcher instance;
	public int Count {
		get { return watchingIceburgs.Count; }
	}
	public List<GameObject> watchingIceburgs = new List<GameObject>();

	public void RemoveIceburg(Iceburg other) {
		watchingIceburgs.Remove (other.gameObject);
	}

	public GameObject GetNextIceburg() {
		if (watchingIceburgs.Count > 0) {
			GameObject iceburg = watchingIceburgs [0];
			watchingIceburgs.Remove (iceburg);
			return iceburg;
		} else {
			return null;
		}
	}

	public GameObject PeekNextIceburg() {
		if (watchingIceburgs.Count > 0) {
			return watchingIceburgs [0];
		} else {
			return null;
		}
	}

	public void WatchIceburg(GameObject iceburg) {
		watchingIceburgs.Add (iceburg);
	}

	void Start () {
		instance = this;
	}
}
