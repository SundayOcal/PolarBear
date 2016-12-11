using UnityEngine;
using System.Collections;

public class FishSpawner : MonoBehaviour {
	public GameObject flyingFishMock;
	float timeToTheInterval = 0;
	float jumpInterval = 0;
	const int kMinFishFlyCount = 1;
	const int kMaxFishFlyCount = 5;

	// Use this for initialization
	void Start () {
		jumpInterval = GenJumpInterval();
	}
	
	// Update is called once per frame
	void Update () {
		timeToTheInterval += Time.deltaTime;
		if (timeToTheInterval >= jumpInterval) {
			Spawn ();
			timeToTheInterval = 0;
		}
	}

	Vector3 GetRandomPositionOnPlane () {
		float x = Random.Range (0.0f, this.transform.localScale.x) + transform.position.x;
		float z = Random.Range (0.0f, this.transform.localScale.z) + transform.position.z;
		return new Vector3(x, 0, z);
	}

	float GenJumpInterval() {
		const float minInterval = 1f;
		const float maxInterval = 2f;
		return Random.Range (minInterval, maxInterval);
	}

	void Spawn() {
		if (Random.Range (0.0f, 1.0f) <= LevelManager.instance.FishSpawnPossibility) {
			GameObject obj = (GameObject)Instantiate(flyingFishMock,
				GetRandomPositionOnPlane(), Quaternion.identity);
			
			//print("Spawn" + obj.transform.position + obj.transform.localRotation);
			obj.GetComponent<FlyingFish> ().FlyCount = Random.Range (kMinFishFlyCount, kMaxFishFlyCount);
			obj.GetComponent<FlyingFish> ().isFreeze = false;
		}
	}
}
