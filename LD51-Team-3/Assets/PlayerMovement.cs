using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private RigidBody2D rb;
   

    // Start is called before the first frame update
   private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector3(0, 14f, 0);
        }
    }
}
