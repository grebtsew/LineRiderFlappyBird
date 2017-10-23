using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class follow_player : MonoBehaviour {


    private Player player;
    private Game_Controller gc;
    private Vector3 startpos;

     void Start()
    {
        player = FindObjectOfType<Player>();
        gc = FindObjectOfType<Game_Controller>();
        startpos = transform.position;
    }

    private void Update()
    {
        if (!gc.gameOver)
        {
        transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        }
    }


    public void reset()
    {
        transform.position = startpos;
    }
}
