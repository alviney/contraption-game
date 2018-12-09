using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Lean.Touch;
public class GameManager : MonoBehaviour {

	public int numOfContraptions;
	// public ContraptionBuilder contraptionBuilder;

	public void Awake() {
		// contraptionBuilder.Setup(numOfContraptions);

		Time.timeScale = 0f;
	}

	public void Begin() {
				
		ReleaseContraptions();
	}

	public void ReleaseContraptions() 
	{
		// contraptionBuilder.ReleaseContraptions();

		Time.timeScale = 1f;
	}
}
