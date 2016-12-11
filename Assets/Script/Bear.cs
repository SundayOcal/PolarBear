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
		
	float bearHeight = 0;

	public void JumpOver (GameObject other, GameObject lookAt = null, float jumpPower = 1) {
		float topOffset = (BoundaryInfo.Height (other) / 2f) + (bearHeight / 2f) ;
		Vector3 dest = other.transform.position + new Vector3 (0, topOffset, 0);
		print ("Jump to " + other + " " + dest);

		transform.DOKill (true); // Stop current movement.
		transform.DOJump (dest, jumpPower, 1, 1f)
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
		bearHeight = BoundaryInfo.Height (this.gameObject) / 2;
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
