using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour
{
   Rigidbody2D rb;
    // Start is called before the first frame update
   // private System.Timers.Timer timer;
    private Stopwatch timer;
    private void Start()
    {
       // timer = new (interval: 1000);
       // timer.start();
       rb = GetComponent<Rigidbody2D>();
     //  Destroy(gameObject);
       timer = new Stopwatch();
       timer.Start();
    }

    // Update is called once per frame
    private void Update()
    {
        if (timer.Elapsed.Seconds >= 10){
            rb.velocity= new Vector2(0, 30);
            timer = new Stopwatch();
            timer.Start();
        }
    }
}
