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
    List<Part> neighbours;

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
    }

    public void RemovePart(Part part)
    {
        parts.Remove(part);
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

    public void DisableParts()
    {
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

    public void CheckForNeighbours(Part part)
    {
        ClearParts();

        neighbours = nc.GetNeighbours(parts, part);

        foreach (Part neighbour in neighbours)
        {
            neighbour.ChangeColor(Color.blue);
        }
    }

}
