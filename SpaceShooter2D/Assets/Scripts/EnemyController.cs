using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    float speedEnemy ;
    public GameObject prefabExplosion;
    // Start is called before the first frame update
    void Start()
    {
        speedEnemy = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        // Get the enemy current postion 
        Vector2 position = transform.position;
        //Compute the enemy new position
        position = new Vector2(position.x, position.y - speedEnemy * Time.deltaTime);
        //Update the enemy new position
        transform.position = position;
        // this is the bottom -left point of the screen;
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        
        if(transform.position.y < min.y)
        {
            Destroy(gameObject);
        }
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Detect collision of the enemy ship with the player ship, or with a player's bullet
        if((collision.tag == "PlayerShipTag") || (collision.tag == "PlayerBulletTag"))
        {
            PlayExplosion();
            // Destroy enemy ship
            Destroy(gameObject);
        }
    }
    void PlayExplosion()
    {
        GameObject explosion = Instantiate(prefabExplosion);
        explosion.transform.position = transform.position;  
    }
}
