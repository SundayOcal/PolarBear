using UnityEngine;
using System.Collections;
using DG.Tweening;

public class FlyingFish : MonoBehaviour {
	GameObject fishObj;
	const float kFlyingHeight = 3f;
	const float kFlyingTime = 0.4f;
	float jumpInterval = 0.5f;
	Vector3 jumpDistance;
	Vector3 destinationVec;
	float timeHasDelayed = 0;

	void Awake () {
		InitializeMovingSetting ();
	}

	void Start () {
		timeHasDelayed = Random.Range(0, jumpInterval);
	}
	
	// Update is called once per frame
	void Update () {
		timeHasDelayed += Time.deltaTime;
		if (timeHasDelayed >= jumpInterval) {
			Jump ();
			timeHasDelayed = 0;
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.GetComponent<Bear> ()) {
			print ("Collide with Flying Fish " + this);
			GameManager.instance.FinishGame ();
		}
	}

	void Jump() {
		SetRendererVisibility (true);
		fishObj.transform.DOLookAt (transform.TransformPoint(destinationVec), 0.1f);
		fishObj.transform.DOLocalJump (destinationVec, kFlyingHeight, 1, kFlyingTime)
			.OnComplete (() => {
				this.Reset();
				this.transform.position += jumpDistance;
		});
	}

	void Reset() {
		// reset destination
		fishObj.transform.localPosition = destinationVec * -1; // Inverse position.

		// reset visibility
		SetRendererVisibility(false);
	}

	void SetRendererVisibility(bool isVisible) {
		Renderer render = this.GetComponentsInChildren<Renderer> ()[0];
		render.enabled = isVisible;
	}

	void InitializeMovingSetting() {
		// Get move destination vector
		fishObj = transform.FindChild ("FishObj").gameObject;
		destinationVec = fishObj.transform.localPosition * -1;
		jumpDistance = destinationVec - fishObj.transform.localPosition;
	}
}
