using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public int collisionDamage;
    public string collisionTag;
    public void Update()
    {
       


        
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        
    }

    
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == collisionTag)
        {
            Player1 hp = collision.gameObject.GetComponent<Player1>();
            hp.Takehit(collisionDamage);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.name == "attackPos")
        {
            
        }
    }








}
