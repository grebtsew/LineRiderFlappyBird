using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line_creator : MonoBehaviour {

    public Transform Parent;
    public GameObject speedlinePrefab;
    public GameObject glidelinePrefab;
    public GameObject bouncylinePrefab;

    public ParticleSystem create_line_effect;

    GameObject lineGO;
    Line activeLine;
    LINE_ENUM line_sort = LINE_ENUM.SPEED;
   
    List<GameObject> line_list = new List<GameObject>();

    public void Undo()
    {
       
        if (line_list != null && line_list.Count > 0) { 
        Destroy(line_list[line_list.Count - 1]);
        line_list.RemoveAt(line_list.Count - 1);
        }
    }

    public void SetLine(LINE_ENUM line)
    {
        line_sort = line;
    }

	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            

            switch (line_sort)
            {
                case LINE_ENUM.SPEED:
                    lineGO = Instantiate(speedlinePrefab);
                    break;
                case LINE_ENUM.BOUNCY:
                    lineGO = Instantiate(bouncylinePrefab);
                    break;
                case LINE_ENUM.GLIDE:
                    lineGO = Instantiate(glidelinePrefab);
                    break;
            }


            activeLine = lineGO.GetComponent<Line>();
            lineGO.transform.SetParent(Parent);
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (create_line_effect != null)
            {
                create_line_effect.Stop();
            }

            if (activeLine != null)
            {
                if (activeLine.TooSmall())
                {
                    Destroy(activeLine);
                } else
                {
                    line_list.Add(activeLine.gameObject);
                }
            }
                activeLine = null;
            }


        if(activeLine != null)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if(create_line_effect != null) {
                create_line_effect.Play();
                create_line_effect.transform.position = mousePos;
            }

            activeLine.UpdateLine(mousePos);

            // direct the speed depending on direction
            if (activeLine.GetComponent<SurfaceEffector2D>() != null)
            {
                if (!activeLine.PossitiveDerivate())
                {
                        activeLine.GetComponent<SurfaceEffector2D>().speed = -Mathf.Abs(activeLine.GetComponent<SurfaceEffector2D>().speed);
                } else
                {
                    activeLine.GetComponent<SurfaceEffector2D>().speed = Mathf.Abs(activeLine.GetComponent<SurfaceEffector2D>().speed);
                }
            }

        }
	}
}
