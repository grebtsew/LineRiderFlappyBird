using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour {

    public LineRenderer lineRenderer;
    public EdgeCollider2D edgeCollider;

     List<Vector2> points;

    public void UpdateLine(Vector2 mousePosition)
    {
        if(points == null)
        {
            points = new List<Vector2>();
            SetPoint(mousePosition);
            return;
        }

        if (Vector2.Distance(points.Last(), mousePosition) > 0.1f)
        {
            SetPoint(mousePosition);
        }
    }

    void SetPoint( Vector2 point)
    {
        points.Add(point);
        lineRenderer.positionCount = points.Count;
        lineRenderer.SetPosition(points.Count-1, point);
        if(points.Count > 1)
        edgeCollider.points = points.ToArray();
    }

    public bool PossitiveDerivate()
    {
        return points[0].x <= points.Last().x;
    }
   
    public bool TooSmall()
    {
        if(points != null) {
        foreach (Vector2 v in points)
        {
           
            if(Vector2.Distance(points[0], v) >= 0.1f)
            {
                return false;
            }
        }
        }
        return true;
    }

}
