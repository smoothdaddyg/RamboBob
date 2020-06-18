using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    // this script should be attached to the players
    // this script allows our player to shoot different types of weapons

    public GameObject prefabBullet; 
    public Transform weapon; 
    public float bulletForce = 20f;


    private float fireRate;   // amount of time player has to wait before another bullet can be fire
    private float timer = 0.0f;    
    private string _WeaponType; // what type of weapon does the player have right now?  

    void Start() {
        _WeaponType = "Hands";
        fireRate = 0.0f;
    }

    void Update() { 

        // increment timer 
        timer += Time.fixedDeltaTime;

        // did user press mouse button?
        if (Input.GetMouseButton(0) && _WeaponType != "Hands") {        

            // has enough time past yet? 
            if(timer > fireRate) {
                Shoot();           
                timer = 0.0f; // reset timer 
            }
            
        }
    }

    void Shoot() { 
        // create an instance of a new bullet and place it at the players firing point
        GameObject bullet = Instantiate(prefabBullet, weapon.position, weapon.rotation); 

        // apply some force to the bullet to make it go! 
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(weapon.up * bulletForce, ForceMode2D.Impulse);
        
        // destroy bullet after a delay 
        Destroy(bullet, 0.5f);
    }


    public void setFireRate(float inFireRate) {
        fireRate = inFireRate;
    }
  
    public void ChangeWeaponType(string inWeaponType, float inFireRate) { 

        _WeaponType = inWeaponType; 

        // update the players weapon graphic
        // get weapon game object
        GameObject objPlayerWeapon = GameObject.FindGameObjectWithTag("PlayerWeapon"); 

        // get spriterender component so we can change the sprite image
        SpriteRenderer rend = objPlayerWeapon.GetComponent<SpriteRenderer>();

        // change the weapon sprite
        rend.sprite = Resources.Load<Sprite>(inWeaponType);

        // change the weapons firerate 
        GameObject objPlayer = GameObject.FindGameObjectWithTag("Player");
        objPlayer.GetComponent<PlayerShoot>().setFireRate(inFireRate);

    }

   
}
