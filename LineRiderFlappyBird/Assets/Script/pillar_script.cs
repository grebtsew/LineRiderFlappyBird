using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pillar_script : MonoBehaviour {

    private Game_Controller gc;
    private bool taken = false;


    public Transform p1;
    public Transform p2;


    // add particles and so on

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Player>() != null && !taken)
        {
            taken = true;
            gc.AddScore();
            Destroy(gameObject, 3);
        }
    }


    public void lowerGap(float decre)
    {
        p1.position = new Vector2(p1.position.x, p1.position.y + decre) ;
        p2.position = new Vector2(p2.position.x, p2.position.y - decre);

    }

        void Start () {
        gc = FindObjectOfType<Game_Controller>();
        setRandomHeight();
	}

    private void setRandomHeight()
    {
        float random_number = Random.Range(-4,4);

        p1.position = new Vector2(p1.position.x, p1.position.y+ random_number);
        p2.position = new Vector2(p2.position.x, p2.position.y+random_number);
    }
	
	
}
