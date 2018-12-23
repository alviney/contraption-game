using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Lean.Touch;

[Serializable]
public class Factory_ContraptionBuilder
{
    private Transform contraptionSpawn;
    private GameObject contraptionPrefab;

    public Factory_ContraptionBuilder(GameObject contraptionPrefab, Transform transform)
    {
        this.contraptionPrefab = contraptionPrefab;

        contraptionSpawn = transform;
    }

    public Contraption Create(int contraptionNumber)
    {
        GameObject newContraption = MonoBehaviour.Instantiate(contraptionPrefab);

        newContraption.name = "contraption-" + contraptionNumber;

        newContraption.transform.SetParent(contraptionSpawn);

        return newContraption.GetComponent<Contraption>(); ;
    }
}
