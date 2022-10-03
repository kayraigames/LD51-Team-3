using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeCode : MonoBehaviour
{
   // public GameObject startPos;
    public TextMeshProUGUI scoreText;
    public GameObject scoreTextObj;
    private Stopwatch timer;
    private float distance;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = scoreTextObj.GetComponent<TextMeshProUGUI>();
        timer = new Stopwatch();
        timer.Start();
    }

    // Update is called once per frame
    void Update()
    {
        long time = timer.ElapsedMilliseconds/1000;
        scoreText.text = "Time(s): "+ time.ToString("F0");
    }
}
