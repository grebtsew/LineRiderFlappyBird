using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line_creator : MonoBehaviour {

    public Transform Parent;
    public GameObject speedlinePrefab;
    public GameObject glidelinePrefab;
    public GameObject bouncylinePrefab;
    private Game_Controller gc;

    public float Minimum_Line_length = 1f;

    public float line_fuel = 100;

    public ParticleSystem create_line_effect;

    GameObject lineGO;
    Line activeLine;
    LINE_ENUM line_sort = LINE_ENUM.SPEED;
   
    List<GameObject> line_list = new List<GameObject>();

    private void Start()
    {
        gc = GetComponent<Game_Controller>();
    }

    public void Reset()
    {
        // reset current
        _mouseUp();

        // remove all lines
        foreach (Line l in FindObjectsOfType<Line>())
        {
            Destroy(l.gameObject);
        }
           
        // clear line_list
        line_list.Clear();
        
    }

    public void Undo()
    {
       
        if (line_list != null && line_list.Count > 0) { 
        Destroy(line_list[line_list.Count - 1]);
        line_list.RemoveAt(line_list.Count - 1);
        }
    }

 

    public void SetLine(LINE_ENUM line)
    {
        if(line_sort != line)
        line_sort = line;
    }

    private void _mouseDown()
    {
        if (create_line_effect != null)
        {
            create_line_effect.Play();

        }

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

    private void _mouseUp()
    {
        if (create_line_effect != null)
        {
            create_line_effect.Stop();
        }

        if (activeLine != null)
        {
            if (activeLine.TooSmall(1f))
            {
                Destroy(activeLine.gameObject);
            }
            else
            {
                line_list.Add(activeLine.gameObject);
            }
        }
        activeLine = null;
    }

    void Update () {

        if (!gc.gameOver) {

        if (Input.GetMouseButtonDown(0))
        {
            _mouseDown();
        }

        if (Input.GetMouseButtonUp(0))
        {
            _mouseUp();
        }


        if(activeLine != null)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (create_line_effect != null)
            {
                create_line_effect.transform.position = mousePos;
            }

            activeLine.UpdateLine(mousePos);

            // direct the speed depending on direction
            if (activeLine.GetComponent<SurfaceEffector2D>() != null)
            {
                if (!activeLine.PositiveDerivate())
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
}
