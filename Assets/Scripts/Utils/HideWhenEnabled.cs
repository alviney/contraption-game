using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideWhenEnabled : MonoBehaviour
{
    public GameObject[] objectsToHide;

    void OnEnable()
    {
        foreach (GameObject obj in objectsToHide)
            obj.SetActive(false);
    }

    void OnDisable()
    {
        foreach (GameObject obj in objectsToHide)
            obj.SetActive(true);
    }
}
