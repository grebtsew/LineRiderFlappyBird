using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class select_line : MonoBehaviour {

    public LINE_ENUM line;
    private Line_creator creator;
    
    void Start()
    {
        creator = FindObjectOfType<Line_creator>();
    }


    public void Clicked()
    {
        creator.SetLine(line);
    }


}
