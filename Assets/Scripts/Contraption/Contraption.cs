using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;

public class Contraption : MonoBehaviour
{
    private Factory_ContraptionOperations co;

    private void Awake()
    {
        co = new Factory_ContraptionOperations();
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, 1);

        Gizmos.color = Color.blue;
        Vector2 center = co.GetCenter(transform);
        Gizmos.DrawSphere(new Vector3(center.x, center.y, 0), 1f);
    }
}
