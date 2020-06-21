using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{

    public GameObject prefabBullet; 
    public Transform weapon; 
    public float bulletForce;   // amount of force bullet has (example 20f)
    public int reLoadRate;  // amount of time between shots (1 = fast, 0 = slow)

    private float timer; 
    private float timerAlarm;
    private bool isEnemyChasingPlayer;   

    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;

        // set the reload rate - everytime timer alarm goes off we reload
        if (reLoadRate == 1){
            timerAlarm = Random.Range(0f, 2f);        
        } else {
            timerAlarm = Random.Range(1f, 2f);
        }
        
    }


    void Update() { 

        // find out if enemy is currently chasing player from the EnemyMove script
        isEnemyChasingPlayer = gameObject.GetComponent<EnemyMove>().ChasePlayer;

        if (isEnemyChasingPlayer == true) {

            timer = timer + Time.fixedDeltaTime;

            if (timer > timerAlarm) {

                Shoot();

                // reset timer
                timer = 0.0f;            

            }
        }
    }

    void Shoot() { 
        // create an instance of a new bullet and place it at the players firing point
        GameObject bullet = Instantiate(prefabBullet, weapon.position, transform.rotation); 

        // apply some force to the bullet to make it go! 
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(weapon.right * bulletForce, ForceMode2D.Impulse);
        
        // destroy bullet we just created after a fraction of a second delay 
        Destroy(bullet, 0.3f);
    }

}
