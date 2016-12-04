using UnityEngine;
using System.Collections;
using DG.Tweening;

public class FlyingFish : MonoBehaviour {
	public bool AutoDestory { get; set; }
	GameObject fishObj;
	const float kFlyingHeight = 6f;
	const int kFlyingTime = 2;
	float jumpInterval;
	Vector3 destinationVec;
	float timeHasDelayed = 0;

	void Awake () {
		InitializeMovingSetting ();
		AutoDestory = false;
	}

	void Start () {
		Reset ();
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
				if (AutoDestory)
					Destroy(this.gameObject);
				else 
					this.Reset();
		});
	}

	void Reset() {
		// reset destination
		destinationVec = destinationVec * -1; // Inverse position.

		// reset interval
		GenJumpInterval();

		// reset visibility
		SetRendererVisibility(false);
	}

	void GenJumpInterval() {
		const float minInterval = 2f; // This should be greater than kFlyingTime.
		const float maxInterval = 3f;
		jumpInterval = Random.Range (minInterval, maxInterval);
	}

	void SetRendererVisibility(bool isVisible) {
		Renderer render = this.GetComponentsInChildren<Renderer> ()[0];
		render.enabled = isVisible;
	}

	void InitializeMovingSetting() {
		// Get move destination vector
		fishObj = transform.FindChild ("FishObj").gameObject;
		destinationVec = fishObj.transform.localPosition;

		GenJumpInterval ();
	}
}
