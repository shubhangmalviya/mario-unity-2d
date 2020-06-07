using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    // Start is called before the first frame update
    public float maxSpeed;
    private Rigidbody2D myRB;
    private bool facingRight = false;
    private SpriteRenderer myRenderer;
    private Animator myAnimator;
    
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        myRenderer = GetComponent<SpriteRenderer>();
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis("Horizontal");

        if (move > 0 && !facingRight)
        {
            Flip();
        }
        else if (move < 0 && facingRight)
        {
            Flip();
        }
        
        myRB.velocity = new Vector2(move * maxSpeed, myRB.velocity.y);
        myAnimator.SetFloat("MoveSpeed", Mathf.Abs(move));
    }

    void Flip()
    {
        facingRight = !facingRight;
        myRenderer.flipX = !myRenderer.flipX;
    }
}
