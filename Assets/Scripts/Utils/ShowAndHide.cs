using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowAndHide : MonoBehaviour {

	public void Show(GameObject obj) {
		obj.SetActive(true);
	}

	public void Hide(GameObject obj) {
		obj.SetActive(false);
	}
}
