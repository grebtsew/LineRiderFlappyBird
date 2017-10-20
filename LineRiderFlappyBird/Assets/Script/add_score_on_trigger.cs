using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class add_score_on_trigger : MonoBehaviour {

    private Game_Controller gc;

	
	void Start () {
        gc = FindObjectOfType<Game_Controller>();
	}

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("hej");

        gc.AddScore();
    }
}
