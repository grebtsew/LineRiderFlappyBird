using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Rigidbody2D rb;
    private Vector2 startpos;
    private follow_player camera;

    void Start()
    {
        camera = FindObjectOfType<follow_player>();
        startpos = gameObject.transform.position;
    }


    void Update () {
        if (Input.GetButtonDown("Start"))
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
        }

        if(gameObject.transform.position.y < -20)
        {
            rb.bodyType = RigidbodyType2D.Static;
            gameObject.transform.position = startpos;
            camera.reset();
        }

      
	}
}
