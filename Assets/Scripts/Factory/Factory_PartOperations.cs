using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory_PartOperations
{
    public void FlipX(SpriteRenderer sr)
    {

        sr.flipX = !sr.flipX;
    }

    public void FlipY(SpriteRenderer sr)
    {
        sr.flipY = !sr.flipY;
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
}
