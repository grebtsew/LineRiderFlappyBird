using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scroll_script : MonoBehaviour {

    private Rigidbody2D rb2d;
    private BoxCollider2D groundCollider;
    private float groundHorizontalLength;
    private Player player;
    private float created_backgrounds;

	// Use this for initialization
	void Start () {
        groundCollider = GetComponent<BoxCollider2D>();
       // groundHorizontalLength = 2*groundCollider.size.x;
        player = FindObjectOfType<Player>();
        created_backgrounds = 1;
        groundHorizontalLength = 28.7f*2f;
  
     
    }
	
	// Update is called once per frame
	void Update () {
		if(player.transform.position.x > groundHorizontalLength*created_backgrounds)
        {
            RepositionBackgroundPossitive();
            created_backgrounds++;
        } else {
        
        if (player.transform.position.x < groundHorizontalLength * (created_backgrounds-1))
        {
            created_backgrounds--;
            RepositionBackgroundNegative();
        }
        }
    }


    private void RepositionBackgroundPossitive()
    {
        Vector2 groundOffset = new Vector2(groundHorizontalLength * created_backgrounds + groundHorizontalLength / 2, 0);
        transform.position = groundOffset;

    }

        private void RepositionBackgroundNegative()
        {
            Vector2 groundOffset = new Vector2(groundHorizontalLength * created_backgrounds - groundHorizontalLength / 2, 0);
            transform.position = groundOffset;
        }
    }
