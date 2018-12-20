using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeighbourCheck
{
    private float distance;
    public NeighbourCheck(float distance = 1.5f)
    {
        this.distance = distance;
    }

    public List<Part> GetNeighbours(List<Part> parts, Part partToCheck)
    {
        List<Part> neighbours = new List<Part>();

        Vector3 ptc = partToCheck.transform.position;

        foreach (Part part in parts)
        {
            if (part == partToCheck)
                break;

            Vector3 p = part.transform.position;

            // Check up & down
            if (Mathf.Round(p.x) == Mathf.Round(ptc.x))
            {
                if (Mathf.Abs(p.y - ptc.y) < distance)
                    neighbours.Add(part);
            }
            // Check left & right
            else if (Mathf.Round(p.y) == Mathf.Round(ptc.y))
            {
                if (Mathf.Abs(p.x - ptc.x) < distance)
                    neighbours.Add(part);
            }
        }

        return neighbours;
    }
}
