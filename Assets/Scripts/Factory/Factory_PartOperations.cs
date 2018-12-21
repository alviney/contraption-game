using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory_PartOperations
{
    public void FlipX(Transform transform)
    {
        transform.localScale = new Vector3(transform.localScale.x * -1, 1, 1);
    }

    public void FlipY(Transform transform)
    {
        transform.localScale = new Vector3(1, transform.localScale.y * -1, 1);
    }

    public void Snap(Transform transform, float gridSize = 1f)
    {
        float x = 0f;
        float y = 0f;

        float reciprocalGrid = 1f / gridSize;

        x = Mathf.Round(transform.position.x * reciprocalGrid) / reciprocalGrid;
        y = Mathf.Round(transform.position.y * reciprocalGrid) / reciprocalGrid;

        transform.position = new Vector3(x, y, transform.position.z);
    }

    public void AddJoint(Part part, Part attached)
    {
        AddHinge(part, attached);
    }

    private void AddHinge(Part part, Part attached)
    {
        HingeJoint2D hinge = part.gameObject.AddComponent<HingeJoint2D>();
        hinge.connectedBody = attached.GetComponent<Rigidbody2D>();
        JointAngleLimits2D limits = hinge.limits;
        limits.min = 0;
        limits.max = 0;
        hinge.limits = limits;
        hinge.useLimits = true;
    }
}
