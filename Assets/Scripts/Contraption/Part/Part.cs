using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;

public class Part : LeanSelectable
{
    public new string name;
    private Color originalColor;
    private Contraption contraption;

    private void Awake()
    {
        OnSelect.AddListener(SelectDown);
        OnSelectUp.AddListener(SelectUp);

        originalColor = GetComponent<SpriteRenderer>().color;
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
            PartsManager.instance.ClearSelectedParts();

            PartsManager.instance.AddToSelectedParts(this);

            ChangeColor(Color.green);
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
            PartsManager.instance.SnapSelectedParts();

            contraption.CheckForNeighbours(this);
        }
        else
        {
            contraption.Deselect();
        }
    }

    public void ClearSelection()
    {
        ChangeColor(originalColor);
    }

    public void ChangeColor(Color color)
    {
        var spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.color = color;
    }
}
