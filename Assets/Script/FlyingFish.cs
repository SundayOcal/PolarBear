using UnityEngine;
using System.Collections;
using DG.Tweening;

public class FlyingFish : MonoBehaviour {
	public bool isFreeze = false;
	public int FlyCount { get; set; }
	GameObject fishObj;
	const float kFlyingHeight = 3f;
	Vector3 jumpDistance;
	Vector3 destinationVec;
	float timeHasDelayed = 0;

	void Awake () {
		InitializeMovingSetting ();
	}

	void Start () {
		timeHasDelayed = Random.Range(0, LevelManager.instance.FishFlyingInterval);
	}
	
	// Update is called once per frame
	void Update () {
		if (isFreeze)
			return;
		
		timeHasDelayed += Time.deltaTime;
		if (timeHasDelayed >= LevelManager.instance.FishFlyingInterval) {
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
		fishObj.transform.DOLocalJump (destinationVec, kFlyingHeight, 1, LevelManager.instance.FishFlyingTime)
			.OnComplete (() => {
				this.Reset();
				this.transform.position += jumpDistance;
				FlyCount -= 1;
				if (FlyCount == 0) {
					Destroy(this.gameObject);
				}
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
		fishObj = transform.FindChild ("BlueMarlin").gameObject;
		destinationVec = fishObj.transform.localPosition * -1;
		jumpDistance = destinationVec - fishObj.transform.localPosition;
		FlyCount = -1;
	}
}
