using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMove : MonoBehaviour
{

    public GameObject player; 
    public Camera cam;

    Vector2 mousePos; // mouse position 

    // Start is called before the first frame update
    void Start()
    {
        // turn the mouse pointer off
        Cursor.visible = false;        
    }

    // Update is called once per frame
    void Update()
    {
        // get mouse position and convert to screen coordinates
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        // move target to mouse position
        transform.position = mousePos;        
    }

    void FixedUpdate()
    {

        // rotate our player towards the target
        Vector2 lookDir = (Vector2)transform.position - (Vector2)player.transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f; 

        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        rb.rotation = angle;       

    }



}
