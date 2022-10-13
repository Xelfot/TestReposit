using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundPatrol : MonoBehaviour
{
    public float speed = 1.5f;

    public bool moveleft = true;
    public Transform groundDetected;
   
    void Start()
    {
        
    }

    
    void Update()
    {

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetected.position, Vector2.down, 1f);
        if (groundInfo.collider == false)
        {
            if (moveleft == true)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                moveleft = false;

            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                moveleft = true;
            }
        }
        transform.Translate(Vector2.left * speed * Time.deltaTime);



        
    }
}

    







