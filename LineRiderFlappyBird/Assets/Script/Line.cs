using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour {

    public LineRenderer lineRenderer;
    public EdgeCollider2D edgeCollider;

     List<Vector2> points;

    private void Start()
    {
        // init collider points, else 0.0 will be collision
        edgeCollider.points = new Vector2[] {new Vector2(0,-10), new Vector2(0, -10) };
    }

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

        if (points.Count > 1) {
        edgeCollider.points = points.ToArray();
            }

        
       
    }

    public bool PositiveDerivate()
    {
        return points[0].x <= points.Last().x;
    }
   
    public bool TooSmall(float margin)
    {
        if(points != null) {
        foreach (Vector2 v in points)
        {
           
            if(Vector2.Distance(points[0], v) >= margin)
            {
                return false;
            }
        }
        }
        return true;
    }

}
