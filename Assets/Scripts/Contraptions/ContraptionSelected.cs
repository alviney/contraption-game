using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContraptionSelected : MonoBehaviour {

	public void SelectContraption() {
		transform.parent.GetComponent<Contraption>().Select();
	}
}
