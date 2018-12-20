using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;

public class PartsManager : MonoBehaviour
{
    public static PartsManager instance = null;
    public GameObject[] partPrefabs;
    public GameObject partSpawnerPrefab;
    public Transform spawnersParent;
    private Factory_PartOperations po;
    public List<Part> selectedParts = new List<Part>();
    private bool isEditing = false;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    private void Start()
    {

        new Factory_PartGenerator(spawnersParent, partPrefabs, partSpawnerPrefab);

        po = new Factory_PartOperations();
    }

    public void FlipPart()
    {
        foreach (Part part in selectedParts)
        {
            po.FlipX(part.transform);
        }
    }

    public bool IsEditing()
    {
        return isEditing;
    }

    public void StartEdit()
    {
        isEditing = true;
    }

    public void StopEdit()
    {
        isEditing = false;

        ClearSelectedParts();
    }

    public void SnapSelectedParts()
    {
        if (isEditing)
            foreach (Part part in selectedParts)
                po.Snap(part.transform);
    }

    public List<Part> GetSelectedParts()
    {
        return selectedParts;
    }

    public void AddToSelectedParts(Part part)
    {
        if (!selectedParts.Contains(part))
            selectedParts.Add(part);
    }

    public void ClearSelectedParts()
    {
        foreach (Part part in selectedParts)
            part.ClearSelection();

        selectedParts.Clear();
    }

    public void DeselectSelectedParts()
    {
        List<Part> partsCopy = new List<Part>(selectedParts);
        foreach (Part part in partsCopy)
            part.Deselect();
    }

    public void DeselectPart(Part part)
    {
        selectedParts.Remove(part);
    }
}
