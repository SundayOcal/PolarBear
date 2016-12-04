using UnityEngine;
using System.Collections;

public class Stage : MonoBehaviour {
	public GameObject flyingFishMock;

	public void MoveStep () {
		Vector3 temp = transform.position;
		temp.x += IceburgSpawner.instance.SpawnDistance;
		transform.position = temp;

		IceburgSpawner.instance.SpawnIce ();
		SpawnFlyingFish ();
	}

	void OnTriggerEnter(Collider other) {
		if (other.GetComponent<Bear> ()) {
			print ("Collide with Stage " + this);
			GameManager.instance.FinishGame ();
		}
	}

	void SpawnFlyingFish() {
		if (Random.Range (0.0f, 1.0f) <= LevelManager.instance.FishSpawnPossibility) {
			GameObject spot = (GameObject)transform.FindChild ("FlyingFishSpawnSpot").gameObject;
			GameObject obj = (GameObject)Instantiate(flyingFishMock,
				spot.transform.position, Quaternion.identity);
			// This objects is temperal. Destroy it after jumping once.
			obj.GetComponent<FlyingFish> ().AutoDestory = true;
		}
	}
}
