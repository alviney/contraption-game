using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Lean.Touch;
public class GameManager : MonoBehaviour {

	public int numOfContraptions;
	public ContraptionManager contraptionManager;

	public void Awake() {
		contraptionManager.Setup(numOfContraptions);
	}

	public void Begin() {
				
		ReleaseContraptions();
	}

	public void ReleaseContraptions() {
		contraptionManager.ReleaseContraptions();
	}
}
