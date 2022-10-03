using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//[RequireComponent(typeof(Image))]
public class Flash : MonoBehaviour
{
    public Image screen;
    //[SerializeField] FlashImage fi = null;
   Rigidbody2D rb;
  //  Image i = null;
    // Start is called before the first frame update
   // private System.Timers.Timer timer;
    private Stopwatch timer;
    private bool flashed = false;
    private void Start()
    {
        // timer = new (interval: 1000);
        // timer.start();
        screen = GetComponent<Image>();
       rb = GetComponent<Rigidbody2D>();
     //  Destroy(gameObject);
       timer = new Stopwatch();
       timer.Start();
    }

    // Update is called once per frame
    private void Update()
    {
        if (timer.Elapsed.Seconds >= 10){
            flashed = true;
            //rb.velocity= new Vector2(0, 30);
            // fi.StartFlashLoop(0.5f, 0, 1);
            timer = new Stopwatch();
            timer.Start();
        }
        FlashMethod();
    }
    public void FlashMethod()
    {
        var color = screen.GetComponent<Image>().color;
        if (flashed)
        {
            color.a = 0.9f;
            flashed = false;
        }
        else if (color.a > 0f)
        {
            color.a -= 0.001f;
        }
        screen.GetComponent<Image>().color = color;
    }
}
