using UnityEngine;
using System.Collections;
using DG.Tweening;

public class Bear : MonoBehaviour {
	public static Bear instance;
	Animator animator;

	public GameObject startingPlace;
	Iceburg currentIceburg = null;
	public Iceburg CurrentIceburg {
		get { return currentIceburg; }
	}

	float jumpHeight = 0.8f;

	public void JumpOver (GameObject other, GameObject lookAt = null) {
		print (other);

		//float topOffset = BoundaryInfo.Height (other) / 2;

		transform.DOMove (other.transform.position + new Vector3 (0, jumpHeight, 0), 1f)
			.SetEase (Ease.OutQuart).OnComplete (() => {
				if (lookAt)
					transform.LookAt (lookAt.transform);
		});

		currentIceburg = other.GetComponent<Iceburg> ();
		if (currentIceburg)
			currentIceburg.melt = true;
		animator.Play ("Jump");
	}

	public void ReadyJump (GameObject other) {
		transform.LookAt (other.transform);
	}

	public void Run () {
		animator.Play ("Run");

		float moveDist = 4;
		transform.DOMove (transform.position + new Vector3 (moveDist, 0, 0), 0.5f)
			.SetEase (Ease.Linear);
	}

	void Awake() {
		instance = this;
		animator = GetComponent<Animator> ();
		print ("Awake");
		print (animator);
	}

	void Start () {
		if (startingPlace) {
			JumpOver (startingPlace);
		}
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
