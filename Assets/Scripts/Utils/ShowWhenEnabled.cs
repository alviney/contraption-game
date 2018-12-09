using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowWhenEnabled : MonoBehaviour {

	public GameObject[] objectsToShow;

	void OnEnable() {
		foreach(GameObject obj in objectsToShow)
			obj.SetActive(true);
	}

	void OnDisable() {
		foreach(GameObject obj in objectsToShow)
			obj.SetActive(false);
	}
}
