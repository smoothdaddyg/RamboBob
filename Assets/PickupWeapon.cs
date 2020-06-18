using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupWeapon : MonoBehaviour
{

    // this script should be attached to each weapon
    // the name of this weapon is whatever it's "tag" is

    public float FireRate;  // what is the fire rate for this weapon?

    void OnCollisionEnter2D(Collision2D col) 
    {

        // Did the player pickup weapon?
        if (col.gameObject.tag.Equals("Player") ) {

            // change the players weapon
            col.gameObject.GetComponent<PlayerShoot>().ChangeWeaponType(gameObject.tag, FireRate);

            // make this weapon disappear
            gameObject.SetActive(false);


        }        
    }


}
