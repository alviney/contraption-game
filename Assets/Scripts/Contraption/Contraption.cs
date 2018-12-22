using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;

public class Contraption : MonoBehaviour
{
    public bool hideCenterGizmos = false;
    public string material;
    private Factory_ContraptionOperations co;
    public List<Part> parts;
    private Factory_PartOperations po;
    private NeighbourCheck nc;
    public Part selectedPart;

    private void Awake()
    {
        co = new Factory_ContraptionOperations();
        po = new Factory_PartOperations();
        nc = new NeighbourCheck();
    }

    void OnDrawGizmos()
    {
        if (hideCenterGizmos)
            return;

        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, 1);

        Gizmos.color = Color.blue;
        Vector2 center = co.GetCenter(transform);
        Gizmos.DrawSphere(new Vector3(center.x, center.y, 0), 1f);
    }

    public void AddPart(Part part)
    {
        parts.Add(part);

        part.SetContraption(this);

        part.transform.SetParent(transform);

        ClearParts();
    }

    public void RemovePart(Part part)
    {
        parts.Remove(part);

        Destroy(part.gameObject);
    }

    public void SnapParts()
    {
        foreach (Part part in parts)
            po.Snap(part.transform);
    }

    public void Select()
    {
        ContraptionsManager.instance.SetCurrentContraption(this);

        GetComponent<LeanSelectable>().Select();
    }

    public void Deselect()
    {
        po.Snap(transform);

        GetComponent<LeanSelectable>().Deselect();
    }

    public Part GetSelectedPart()
    {
        return selectedPart;
    }

    public void SetSelectedPart(Part part)
    {
        selectedPart = part;

        selectedPart.attrs.isSelected = true;
    }

    public void DisableParts()
    {
        ClearParts();

        foreach (Part part in parts)
            part.DisablePart();
    }

    public void EnableParts()
    {
        foreach (Part part in parts)
            part.EnablePart();
    }

    public void ClearParts()
    {
        foreach (Part part in parts)
            part.ClearSelection();
    }

    public void AddJoints()
    {
        foreach (Part part in parts)
        {
            List<Part> neighbours = nc.GetNeighbours(parts, part);
            foreach (Part neighbour in neighbours)
                po.AddJoint(part, neighbour);
        }
    }

    public void RemoveJoints()
    {
        foreach (Part part in parts)
            po.RemoveJoint(part);
    }

    public void ShowNeighbours(Part part)
    {
        List<Part> neighbours = nc.GetNeighbours(parts, part);

        foreach (Part neighbour in neighbours)
        {
            neighbour.attrs.isNeighbour = true;
            neighbour.ApplyColor();
        }

        if (parts.Count != 1 && neighbours.Count < 1)
        {
            RemovePart(part);
        }
    }

    public void ToggleGravity()
    {
        foreach (Part part in parts)
        {
            RigidbodyType2D bodyType = part.GetComponent<Rigidbody2D>().bodyType;
            part.GetComponent<Rigidbody2D>().bodyType = bodyType == RigidbodyType2D.Kinematic ? RigidbodyType2D.Dynamic : RigidbodyType2D.Kinematic;
        }
    }

    public bool IsReadyToBuild
    {
        get { return parts.Count > 0; }
    }
}
