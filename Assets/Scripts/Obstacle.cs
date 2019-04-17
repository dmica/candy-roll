using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

    Rigidbody2D rb;

    [SerializeField] //allow changes to field moveSpeed even if its private
    private float moveSpeed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


	
	// Update is called once per frame
	void Update () {
        //check if x position is less than 15f, and destroy object if it's true
		if(transform.position.x < -15f)
        {
            Destroy(gameObject);
        }
	}

    private void FixedUpdate()
    {
        rb.velocity = Vector2.left * moveSpeed;
    }
}
