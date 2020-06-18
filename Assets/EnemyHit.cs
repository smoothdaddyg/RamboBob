using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{

    public GameObject explosion; 
    public float health;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // What hit us?
    void OnCollisionEnter2D(Collision2D col) 
    {

        // What hit our enemy?
        if (col.gameObject.tag.Equals("PlayerBullet") ) {

            // make an explosion
            GameObject explode = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(explode, 1f);            

            // reduce health evertime we are hit
            health--;

            // is health 0, then kill enemy
            if (health == 0) {
                gameObject.SetActive(false);
            }
        }        
        
    }

/*
    // OnCollision executes when enemy is hit by something
    void OnCollisionEnter2D(Collision2D col) 
    {
        // Did Enemy hit Player?
        if (col.gameObject.tag.Equals("Bob")) {
            GameObject explode = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(explode, 2f);
            
            // game over!  Find gameCommand object and called the GameOver method            
            gameCommand.GetComponent<CommandControl>().GameOver();          
        }        
    }

*/

}
