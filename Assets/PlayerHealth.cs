using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // this script should be attached to the player
    // this script keeps track of the players health - gives the player a heart

    public float playerHealth = 20;
    public GameObject explosion; 





    // What hit us?
    void OnCollisionEnter2D(Collision2D col) 
    {

        //Debug.Log("boom");
        //Debug.Log(col.gameObject.tag);

        // What hit our player?
        if (col.gameObject.tag.Equals("EnemyBullet") ) {
            // make an explosion so users know player was hit
            GameObject explode = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(explode, 1f);

            // reduce player health            
            playerHealth--;
            Debug.Log(playerHealth);
        }        

    }



}
