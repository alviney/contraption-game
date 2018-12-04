using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowWhenEnabled : MonoBehaviour {

	public GameObject objectToShow;

	void OnEnable() {
		objectToShow.SetActive(true);
	}

	void OnDisable() {
		objectToShow.SetActive(false);
	}
}
