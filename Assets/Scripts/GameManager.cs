using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Lean.Touch;
public class GameManager : MonoBehaviour
{

    public int numOfContraptions;

    public void Awake()
    {
        Time.timeScale = 0f;
    }

    public void Begin()
    {
        ContraptionsManager.instance.CopyContraptions();

        ReleaseContraptions();
    }

    public void Replay()
    {
        Time.timeScale = 0f;

        ContraptionsManager.instance.DestroyContraptionsCopy();
    }

    public void ReleaseContraptions()
    {
        Time.timeScale = 1f;
    }
}
