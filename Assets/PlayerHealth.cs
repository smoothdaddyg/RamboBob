using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Description: 
    // This script should be attached to the player.
    // This script keeps track of a players health - gives the player a heart
    // Four Hearts are displayed on the screen and position at top of camera view
    
    public float playerHealthMax = 20;
    public float playerHealthCurrent = 20;  // each time a player gets hit, his health decreases by one    
    public GameObject heart;
    public GameObject explosion;     

    // our hearts
    public Sprite heartEmpty;
    public Sprite heartFull;
    private float heartMaxHealth;  // how much health can one heart hold

    private GameObject[] healthBar;  // array to hold all our heart icons
    private float cameraHeight; 
    private float cameraWidth; 

    


    void Start() {

        // find height and width of camera object
        cameraHeight = Camera.main.orthographicSize - 0.5f;
        cameraWidth = cameraHeight * Camera.main.aspect;

        // create four empty heart icons
        healthBar = new GameObject[4];  // create an array with room for four game objects
        healthBar[0] = Instantiate(heart, transform.position, Quaternion.identity);  // create a new game object, set its position (same as player) and no rotation
        healthBar[1] = Instantiate(heart, transform.position, Quaternion.identity);
        healthBar[2] = Instantiate(heart, transform.position, Quaternion.identity);
        healthBar[3] = Instantiate(heart, transform.position, Quaternion.identity);    

        // determine how much health one heart can hold
        heartMaxHealth = playerHealthMax / 4; 

    }

    // Update is called once per frame
    void Update()
    {
        // display four hearts
        displayHeartIcon(0);
        displayHeartIcon(1);
        displayHeartIcon(2);
        displayHeartIcon(3); 
    }


    void displayHeartIcon(int arrayIndexNumber) {

        // where should the heart icon go? create a vector position for icon
        Vector3 iconPosition = new Vector3(transform.position.x - cameraWidth + arrayIndexNumber * 2, transform.position.y + cameraHeight, 10);

        // set icons position
        healthBar[arrayIndexNumber].transform.position = iconPosition;

        // does player have enough health to turn this heart icon on?  
        // there are 4 hearts, the player can handle 20 hits, each heart indicates 5 hits left

        if (playerHealthCurrent > (arrayIndexNumber * 5) ) {
            // use a full heart
            healthBar[arrayIndexNumber].GetComponent<SpriteRenderer>().sprite = heartFull;
        } else {
            // use an empty heart
            healthBar[arrayIndexNumber].GetComponent<SpriteRenderer>().sprite = heartEmpty;
        }

    }  


    // What hit us?
    void OnCollisionEnter2D(Collision2D col) 
    {

        //Debug.Log("boom");
        //Debug.Log(col.gameObject.tag);

        // What hit our player?
        if (col.gameObject.tag.Equals("EnemyBullet") ) {
            // make an explosion so user knows player was hit
            GameObject explode = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(explode, 1f);

            // reduce player health            
            playerHealthCurrent--;
            //Debug.Log(playerHealthCurrent);

            if (playerHealthCurrent == 0) {
                reSpawn(); 
            }
        }        

    }

    // reSpawn player to starting point
    void reSpawn() {

        // create a vector position (this is Bobs location at start of the game)
        Vector3 playerPostionAtStartOfGame = new Vector3(5, -2, 0);

        // set players position to this vector
        transform.position = playerPostionAtStartOfGame; 

    }


}
