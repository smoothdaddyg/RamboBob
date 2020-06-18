using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySneeze : MonoBehaviour
{

    public GameObject sneeze;
    public Transform weapon;      
    
    private float timer; 
    private float timerAlarm;
    private bool isEnemyChasingPlayer; 

    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
        timerAlarm = Random.Range(1f, 2f);        
    }

    // Update is called once per frame
    void Update()
    {
        isEnemyChasingPlayer = gameObject.GetComponent<EnemyMove>().ChasePlayer;

        if (isEnemyChasingPlayer == true) {

            timer = timer + Time.fixedDeltaTime;

            if (timer > timerAlarm) {
 
                // create a new sneeze at the enemy's weapon location and rotate it an additional 90 degrees
                GameObject newSneeze = Instantiate(sneeze, weapon.position, weapon.rotation * Quaternion.Euler(0, 0, -90) ); 

                // destroy sneeze after few seconds
                Destroy(newSneeze, 2f);

                // reset timer
                timer = 0.0f;            

            }
        }
        
    }
}
