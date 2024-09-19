using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletController : MonoBehaviour
{
     float speedBullet;
     void Start()
    {
        speedBullet = 8f;
    }
    // Update is called once per frame
    void Update()
    {
        // Get the bullet's current  position
        Vector2 position = transform.position; 

        // Compute the bullet's new position
        position = new Vector2(position.x, position.y + speedBullet * Time.deltaTime);
        transform.position = position;

        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1,1));
       
        
        // if the bullet went outside the screen on the top , then destroy the bullet
        if(transform.position.y > max.y)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Detect collision of the player bullet with an enemy ship
        if(collision.tag == "EnemyShipTag")
        {
            // Destroy this player bullet
            Destroy(gameObject);
        }
    }
}

