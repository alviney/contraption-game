using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;

public class Part : LeanSelectable
{
    private Color originalColor;
    private Contraption contraption;

    private void Awake()
    {
        OnSelect.AddListener(SelectDown);
        OnSelectUp.AddListener(SelectUp);
        OnDeselect.AddListener(Deselected);

        originalColor = GetComponent<SpriteRenderer>().color;
    }

    public void SetContraption(Contraption contraption)
    {
        this.contraption = contraption;
    }
    private void SelectDown(LeanFinger finger)
    {
        if (PartsManager.instance.IsEditing())
        {
            PartsManager.instance.Select(this);

            ChangeColor(Color.green);
        }
        else
        {
            contraption.Select();
            Deselect();
        }
    }

    private void SelectUp(LeanFinger finger)
    {
        if (PartsManager.instance.IsEditing())
        {
            PartsManager.instance.SnapSelectedParts();
        }
        else
        {
            // contraption.Deselect();
        }
    }

    private void Deselected()
    {
        PartsManager.instance.DeselectPart(this);

        ChangeColor(originalColor);
    }

    private void ChangeColor(Color color)
    {
        var spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.color = color;
    }
}
