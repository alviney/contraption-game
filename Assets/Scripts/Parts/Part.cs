using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;

public class Part : LeanSelectable {

	public Contraption contraption;
	public SnapToGrid snapper;

	private void Awake()
	{
		OnSelect.AddListener(SelectDown);
		OnSelectUp.AddListener(SelectUp);

		snapper = GetComponent<SnapToGrid>();
	}

	private void SelectDown(LeanFinger finger) 
	{
		SelectContraption();
	}

	private void SelectUp(LeanFinger finger) 
	{
		this.Select();

		contraption.SnapSelectedParts();
	}

	public void Snap() 
	{
		snapper.Snap();
	}

	public void SelectContraption() 
	{
		contraption.Select(this);
	}


}
