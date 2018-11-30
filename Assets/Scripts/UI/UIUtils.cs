using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIUtils : MonoBehaviour {

	public void Hide(GameObject go) {
		go.SetActive(false);
	}

	public void Show(GameObject go) {
		go.SetActive(true);
	}
}
