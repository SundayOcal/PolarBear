using UnityEngine;
using System.Collections;

public class Bear : MonoBehaviour {
	public static Bear instance;

	public GameObject startingPlace;
	Iceburg currentIceburg = null;
	public Iceburg CurrentIceburg {
		get { return currentIceburg; }
	}
	float jumpHeight = 0.8f;

	public void JumpOver (GameObject other) {
		float topOffset = BoundaryInfo.Height (other) / 2 + jumpHeight;
		transform.position = other.transform.position + new Vector3(0, topOffset, 0);
		currentIceburg = other.GetComponent<Iceburg> ();
		if (currentIceburg)
			currentIceburg.melt = true;
	}

	void Awake() {
		instance = this;
	}

	void Start () {
		JumpOver (startingPlace);
	}
	
	// Update is called once per frame
	void Update () {
		// not call since iceburg do not move anymore. leave it for the further use.
		//SyncPositionToTheIceburg ();
	}

	void SyncPositionToTheIceburg() {
		if (currentIceburg) {
			var pos = currentIceburg.transform.position;
			transform.position = new Vector3 (pos.x, transform.position.y, pos.z);
		}
	}
}
