using UnityEngine;
using System.Collections;

public class Stage : MonoBehaviour {
	public GameObject flyingFishMock;

	public void MoveStep () {
		Vector3 temp = transform.position;
		temp.x += IceburgSpawner.instance.SpawnDistance;
		transform.position = temp;

		IceburgSpawner.instance.SpawnIce ();
	}

	void OnTriggerEnter(Collider other) {
		if (other.GetComponent<Bear> ()) {
			print ("Collide with Stage " + this);
			GameManager.instance.FinishGame ();
		}
	}
}
