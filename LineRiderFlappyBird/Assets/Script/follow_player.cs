using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class follow_player : MonoBehaviour {

    private Player player;
    private Vector3 startpos;
    public Text path_text;


    void Start () {
        player = FindObjectOfType<Player>();
        startpos = transform.position;
    }
	
	
	void Update () {
        transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        path_text.text = Mathf.Round(player.transform.position.x + Time.deltaTime).ToString();
    }

    public void reset()
    {
        gameObject.transform.position = startpos;
    }
}
