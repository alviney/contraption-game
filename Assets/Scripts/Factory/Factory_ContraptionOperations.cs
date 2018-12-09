using System.Collections;
using UnityEngine;

public class Factory_ContraptionOperations
{
    public Vector2 GetCenter(Transform transform)
    {
        float totalX = 0f;
        float totalY = 0f;
        foreach (Transform part in transform)
        {
            totalX += part.transform.position.x;
            totalY += part.transform.position.y;
        }

        float centerX = totalX / transform.childCount;
        float centerY = totalY / transform.childCount;

        return new Vector2(centerX, centerY);
    }

    public void CenterParts(Transform transform)
    {
        Vector2 center = GetCenter(transform);
        Vector2 offset = new Vector2(transform.position.x, transform.position.y) - center;
        foreach (Transform part in transform)
        {
            part.position += new Vector3(offset.x, offset.y, 0);
        }
        transform.position = center;
    }

}
