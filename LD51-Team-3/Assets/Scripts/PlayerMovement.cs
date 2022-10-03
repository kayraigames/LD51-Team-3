using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayerMovement : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    public GameObject scoreTextObj;
    public TextMeshProUGUI scoreText2;
    public GameObject scoreTextObj2;
    private Rigidbody2D rb;
    private BoxCollider2D collide;
    private SpriteRenderer sprite;
    private Animator anim;
    public GameOver go;
    private Stopwatch timer2;
    bool dead;
    [SerializeField] private LayerMask jumpableGround;
    private Stopwatch timer;
    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    private enum MovementState { still, walking, jumping, falling }

    // Start is called before the first frame update
    private void Start()
    {
        scoreText.text = "";
        scoreText2.text = "";
        rb = GetComponent<Rigidbody2D>();
        collide = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        go = GetComponent<GameOver>();
        timer = new Stopwatch();
        timer.Start();
        dead = false;
    }

    // Update is called once per frame
    private void Update()

    {
        if (dead == false)
        {
            dirX = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

            if (Input.GetButtonDown("Jump") && IsGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
            UpdateAnimationState();

            if (timer.Elapsed.Seconds >= 10)
            {
                // flashed = true;
                // rb.checkDeath();
                checkDeath();
                //rb.velocity= new Vector2(0, 30);
                // fi.StartFlashLoop(0.5f, 0, 1);
                timer = new Stopwatch();
                timer.Start();
            }
        }
        else if(timer2.Elapsed.Seconds>=5)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void UpdateAnimationState()
    {
        MovementState state;
        if (dirX > 0f)
        {
            state = MovementState.walking;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.walking;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.still;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(collide.bounds.center, collide.bounds.size, 0f, Vector2.down, .1f, jumpableGround);

    }
    public void checkDeath()
    {
        //called when flash goes off
        //check if player collider is overlapping with any collider(doc)
        //dont use contact filter
        //ContactFilter2D.NoFilter
        //loop through array of results of collider 2d, check if the tag(this.tranform.tag) is hideable
        //if no hidable game over
        //for death animation
        Collider2D[] results = new Collider2D[10];
        ContactFilter2D cf = new ContactFilter2D();
        cf.NoFilter();
        int cols = collide.OverlapCollider(cf, results); ;
        bool hiding = false;
        for (int i = 0; i < cols; i++)
        {
            if (String.Equals(results[i].gameObject.tag, "Hideable"))
            {
                hiding = true;
            }
        }
        if (hiding == false)
        {
            dead = true;
            anim.SetTrigger("death");
            go.dead = true;
            scoreText.text = "GAME OVER!";
            timer2 = new Stopwatch();
            timer2.Start();
          
            
        }
        
    }
}
