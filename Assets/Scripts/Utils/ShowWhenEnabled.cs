using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowWhenEnabled : MonoBehaviour {

	public GameObject objectToShow;

	void OnEnable() {
		Debug.Log("ENABLE");
		objectToShow.SetActive(true);
	}

	void OnDisable() {
		Debug.Log("DISABLE");
		objectToShow.SetActive(false);
	}
}
