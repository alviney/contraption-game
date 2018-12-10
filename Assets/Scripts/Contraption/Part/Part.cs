using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;

public class Part : LeanSelectable
{
  private void Awake()
  {
    OnSelect.AddListener(SelectDown);
    OnSelectUp.AddListener(SelectUp);
    OnDeselect.AddListener(Deselected);
  }

  private void SelectDown(LeanFinger finger)
  {
    if (!PartsManager.instance.IsEditing())
    {
      this.Deselect();
      ContraptionsManager.instance.SelectContraption(transform.parent.GetComponent<Contraption>());
    }
    else
      PartsManager.instance.Select(this);
  }

  private void SelectUp(LeanFinger finger)
  {
    PartsManager.instance.SnapSelectedParts();
  }

  private void Deselected()
  {
    PartsManager.instance.DeselectPart(this);
  }
}
