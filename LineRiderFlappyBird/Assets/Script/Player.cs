using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Rigidbody2D rb;
    private Vector2 startpos;
    private follow_player camera;
    private Game_Controller gc;
    private Line_creator line_Creator;

    private float rot_speed_amplify = 100;

    void Start()
    {
        gc = FindObjectOfType<Game_Controller>();
        camera = FindObjectOfType<follow_player>();
        startpos = gameObject.transform.position;
        line_Creator = FindObjectOfType<Line_creator>();
    }

    public void initiate()
    {
         rb.bodyType = RigidbodyType2D.Dynamic;
    }

    public void reset_Player()
    {
        rb.bodyType = RigidbodyType2D.Static;
        gameObject.transform.position = startpos;
        camera.reset();
    }


    void Update () {


        if(rb.bodyType != RigidbodyType2D.Static) {
        // rotate
        rb.MoveRotation(rb.rotation + rot_speed_amplify * rb.velocity.x*Time.fixedDeltaTime);

        // dead
        if (gameObject.transform.position.y < -20)
        {
            died();
        }

        }

    }

    private void died()
    {
        gc.GameOver();
        reset_Player();
        line_Creator.Reset();
    }


    void OnCollisionEnter2D(Collision2D collision)
    {

      
        if (collision.collider.tag == "Gate")
        {
            died();
            Destroy(collision.gameObject);
        }

       
        
    }
}
