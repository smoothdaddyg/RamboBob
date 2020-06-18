using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{

    public GameObject Doors; 
    public GameObject OpenDoorButton;

    void OnCollisionEnter2D(Collision2D col) 
    {

        // Did the player touch button?
        if (col.gameObject.tag.Equals("Player") ) {

            OpenDoorButton.SetActive(true);
            Doors.SetActive(false);
            gameObject.SetActive(false);
            
        }        
    }



}
