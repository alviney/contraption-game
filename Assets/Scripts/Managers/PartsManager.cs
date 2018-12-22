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
    private Contraption currrentContraption;
    private Factory_PartOperations po;
    private bool isEditing = false;
    private bool isDragging = false;

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

    public void SetCurrentContraption(Contraption contraption)
    {
        currrentContraption = contraption;
    }

    public void FlipPart()
    {
        po.FlipX(currrentContraption.GetSelectedPart().transform);
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
    }

    public void SetIsDragging(bool isDragging)
    {
        this.isDragging = isDragging;
    }

    public bool GetIsDragging()
    {
        return isDragging;
    }
}
