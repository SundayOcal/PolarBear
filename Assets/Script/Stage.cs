using UnityEngine;
using System.Collections;

public class Stage : MonoBehaviour {

	public void MoveStep () {
		Vector3 temp = transform.position;
		temp.x += IceburgSpawner.instance.SpawnDistance;
		transform.position = temp;

		IceburgSpawner.instance.SpawnIce ();
	}
}
