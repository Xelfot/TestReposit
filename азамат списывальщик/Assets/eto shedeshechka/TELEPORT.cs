using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TELEPORT : MonoBehaviour
{
    public GameObject TELEPORT1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            collision.gameObject.transform.position = TELEPORT1.gameObject.transform.position;


        }










    }



}
