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
        SetCurrentContraption(ContraptionBuilder.Create(contraptions.Count));

        StartEdit();
    }

    public void EditContraption()
    {
        StartEdit();
    }

    public void BuildContraption()
    {
        if (!currentContraption.IsReadyToBuild)
        {
            CancelContraption();
            return;
        }

        contraptions.Add(currentContraption);

        currentContraption.AddJoints();

        StopEdit();
    }

    public void RebuildContraption()
    {
        if (!currentContraption.IsReadyToBuild)
        {
            CancelContraption();
            return;
        }

        currentContraption.RemoveJoints();

        currentContraption.AddJoints();

        StopEdit();
    }

    public void StartEdit()
    {
        if (PartsManager.instance)
            PartsManager.instance.StartEdit();

        if (currentContraption)
            currentContraption.EnableParts();
    }

    public void StopEdit()
    {
        if (PartsManager.instance)
            PartsManager.instance.StopEdit();

        if (currentContraption)
        {
            // TODO - Reset GameObject to state before editing started.
            co.CenterParts(currentContraption.transform);

            currentContraption.DisableParts();
        }
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

        StopEdit();
    }

    public void SetCurrentContraption(Contraption contraption)
    {
        currentContraption = contraption;

        PartsManager.instance.SetCurrentContraption(contraption);
    }

    public void ToggleGravity()
    {
        currentContraption.ToggleGravity();
    }

    public void SetMaterial(string material)
    {
        currentContraption.material = material;
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
