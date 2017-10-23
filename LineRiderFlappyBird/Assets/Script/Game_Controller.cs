﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Controller : MonoBehaviour {

    public Text score_text;
    private int score = 0;
    public bool gameOver = true;
    private Player player;
    public Text time;
    private GateSpawner gs;
    public Text path_text;
    private Game_Controller gc;

    private float time_value;
   

     void Start()
    {
        gs = FindObjectOfType<GateSpawner>();
        player = FindObjectOfType<Player>();
      
    }

    public void StartGame()
    {
        gs.Reset();
        time_value = 0;
        gameOver = false;
        score = 0;
        score_text.text = score.ToString();
    }


    void Update()
    {
        if (Input.GetButtonDown("Start"))
        {
            StartGame();
            player.initiate();
        }

        if (!gameOver) { 

        time_value += Time.deltaTime;
        time.text = Mathf.Round(time_value).ToString();
            
            path_text.text = Mathf.Round(player.transform.position.x + Time.deltaTime).ToString();
        }
    }

    public void GameOver()
    {
        gameOver = true;
    }

    public void AddScore()
    {
        score++;
        score_text.text = score.ToString();
    }

   
}
