using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    Rigidbody2D rb;

    //set height of player jump in upwards dierection
    [SerializeField]
    float jumpForce;

    bool grounded;

    bool gameOver = false;

    //store reference to Rigidbody2D that is attached to player
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

	// Update is called once per frame
	void Update () {
        //check if left mouse button is clicked on screen, and if game is over
        if (Input.GetMouseButtonDown(0) && !gameOver)
            //if left mouse button is pressed, make player jump
        {
            if (grounded)
            {
                Jump();
            }
        }
	}

    //allow player to jump on upwords direction
    void Jump()
    {
        //set grounded to false, because when player jumps he is not grounded anymore
        grounded = false;
        rb.velocity = Vector2.up * jumpForce;

        //increment score every time player jumps
        GameManager.instance.IncrimentScore();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //chek if player collisioned with object that has tag 'Ground' attached to it, 
        //and if yes set it to true
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            //destroy objects on collision
            Destroy(collision.gameObject);
            //stop spawning obejcts
            GameManager.instance.GameOver();
            gameOver = true;
        }
    }
}
