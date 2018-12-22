using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;

public struct PartAttrs
{
    public bool isNeighbour;
    public bool isSelected;
}
public class Part : LeanSelectable
{
    public new string name;
    public PartAttrs attrs;
    private Color originalColor;
    private Contraption contraption;

    private void Awake()
    {
        OnSelect.AddListener(SelectDown);
        OnSelectUp.AddListener(SelectUp);
        OnDeselect.AddListener(Deselect);

        originalColor = GetComponent<SpriteRenderer>().color;

        attrs.isNeighbour = false;
        attrs.isSelected = false;
    }

    public void DisablePart()
    {
        GetComponent<LeanTranslate>().enabled = false;
    }

    public void EnablePart()
    {
        GetComponent<LeanTranslate>().enabled = true;
    }

    public void SetContraption(Contraption contraption)
    {
        this.contraption = contraption;
    }

    private void SelectDown(LeanFinger finger)
    {
        if (PartsManager.instance.IsEditing())
        {
            bool isDragging = PartsManager.instance.GetIsDragging();

            DeselectOnUp = !isDragging;

            if (!isDragging)
                contraption.ClearParts();

            contraption.SetSelectedPart(this);

            ApplyColor();
        }
        else
        {
            contraption.Select();
        }
    }

    private void SelectUp(LeanFinger finger)
    {
        if (PartsManager.instance.IsEditing())
        {
            contraption.SnapParts();

            if (DeselectOnUp)
                contraption.ShowNeighbours(this);
        }
        else
        {
            contraption.Deselect();
        }
    }

    private void Deselect()
    {
        if (!PartsManager.instance.IsEditing())
            return;

        ClearSelection();
        if (contraption.GetSelectedPart() == this)
        {
            attrs.isSelected = true;
            ApplyColor();
        }
    }

    public void ClearSelection()
    {
        attrs.isNeighbour = false;
        attrs.isSelected = false;
        ApplyColor();
    }

    public void ApplyColor()
    {
        Color color;

        if (attrs.isSelected)
            color = Color.green;
        else if (attrs.isNeighbour)
            color = Color.blue;
        else
            color = originalColor;

        var spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = color;
    }
}
