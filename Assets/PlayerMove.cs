using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // this script should be attached to the player

    public float moveSpeed = 5f;
    public Rigidbody2D rb; 

    Vector2 movement; 


    // Update is called once per frame
    void Update()
    {
        
        // get users input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

    }


    void FixedUpdate()
    {

        // move our player
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

    }


}
