using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Controller : MonoBehaviour {

    public Text score_text;
    private int score = 0;





    public void AddScore()
    {
        score++;
        score_text.text = score.ToString();
    }
}
