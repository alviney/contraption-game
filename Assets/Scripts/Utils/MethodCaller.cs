using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class MethodCaller : MonoBehaviour
{
    public UnityEvent onEnable;
    public UnityEvent onDisable;

    public void OnEnable()
    {
        onEnable.Invoke();
    }

    public void OnDisable()
    {
        onDisable.Invoke();
    }
}
