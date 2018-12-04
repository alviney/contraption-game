using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;

public class SnapToGrid : LeanSelectableBehaviour {

	public float gridSize = 0.5f;
	public bool snap = true;
	float x = 0f;
	float y = 0f;

	protected override void OnSelectUp(LeanFinger finger)
	{

	}
	public void Snap() 
	{
		if (!snap) return;
		
		float reciprocalGrid = 1f / gridSize;

		x = Mathf.Round(transform.position.x * reciprocalGrid) / reciprocalGrid;
		y = Mathf.Round(transform.position.y * reciprocalGrid) / reciprocalGrid;

		transform.position = new Vector3(x, y, transform.position.z);
	}
}
