using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public Rigidbody2D rb; 
    public GameObject player; 
    public float moveSpeed; // move speed (example: = .1f) 
    public float EnemyEngageDistance; // distance to engage player (example: 14.0f)
    public bool ChasePlayer = false;
    public float angleToPlayer; 

    private Vector2 movement;

  
    // Update is called once per frame
    void Update()
    {

        // find the distance between enemy and player
        float dist = Vector3.Distance(player.transform.position, transform.position);

        // if player is close, then engage
        if (dist < EnemyEngageDistance) { 
            ChasePlayer = true;
        } else { 
            ChasePlayer = false;
        }

        // what direction is the enemy?
        Vector3 direction = player.transform.position - transform.position;

        // calculate angle to face enemy
        angleToPlayer = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // rotate the enemy and get direction to move
        rb.rotation = angleToPlayer;
        direction.Normalize();
        movement = direction;     
    
    }

    void FixedUpdate() {
        moveSprite(movement);      
    }

    void moveSprite(Vector2 direction) {        
        if (ChasePlayer) {
            // move enemy toward player
            rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
        }
    }



}
