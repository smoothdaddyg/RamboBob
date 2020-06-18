using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{

    public GameObject prefabBullet; 
    public Transform weapon; 
    public float bulletForce = 20f;
    public float fireRate = 0.1f;   // amount of time player has to wait before another bullet can be fire

    private float timer; 
    private float timerAlarm;
    private bool isEnemyChasingPlayer;   

    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
        timerAlarm = Random.Range(1f, 2f);        
    }


    void Update() { 

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
        
        // destroy bullet after a delay 
        Destroy(bullet, 0.4f);
    }

}
