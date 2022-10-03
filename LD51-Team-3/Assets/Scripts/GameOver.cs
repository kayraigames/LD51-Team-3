using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOver : MonoBehaviour
{
   // public GameObject startPos;
    public TextMeshProUGUI scoreText;
    public GameObject scoreTextObj;
    public bool dead;
   // private Stopwatch timer;
   // private float distance;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "";
        dead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (dead == true)
        {
            scoreText.text = "GAME OVER";
        }
  
    }
}
