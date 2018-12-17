using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;

public class ContraptionsManager : MonoBehaviour
{
    public static ContraptionsManager instance = null;
    public GameObject contraptionPrefab;
    public Transform contraptionSpawn;
    private List<Contraption> contraptions = new List<Contraption>();
    public Contraption currentContraption;
    private Factory_ContraptionBuilder ContraptionBuilder;
    private Factory_ContraptionOperations co;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        ContraptionBuilder = new Factory_ContraptionBuilder(contraptionPrefab, contraptionSpawn);
        co = new Factory_ContraptionOperations();
    }

    public void CreateContration()
    {
        currentContraption = ContraptionBuilder.Create(contraptions.Count);
        EditContraption();
    }

    public void BuildContraption()
    {
        contraptions.Add(currentContraption);

        FinishEditing();
    }

    public void EditContraption()
    {
        PartsManager.instance.StartEditing();

        currentContraption.EnableParts();
    }

    public void FinishEditing()
    {
        // TODO - Reset GameObject to state before editing started.
        co.CenterParts(currentContraption.transform);

        currentContraption.DisableParts();

        PartsManager.instance.StopEditing();

    }

    public void DeleteContraption()
    {
        contraptions.Remove(currentContraption);

        CancelContraption();
    }

    public void CancelContraption()
    {
        if (!contraptions.Contains(currentContraption))
            Destroy(currentContraption.gameObject);
    }

    public void SetCurrentContraption(Contraption contraption)
    {
        currentContraption = contraption;
    }

    public void AddGravity()
    {
        currentContraption.GetComponent<Rigidbody2D>().gravityScale = 1;
    }

    public Contraption GetCurrentContraption()
    {
        return currentContraption;
    }

    public void ReleaseContraptions()
    {
        foreach (Contraption contraption in contraptions)
            contraption.gameObject.AddComponent<Rigidbody2D>();
    }
}
