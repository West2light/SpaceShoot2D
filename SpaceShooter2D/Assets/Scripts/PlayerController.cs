using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public GameObject prefabBullet;
    public Transform bulletPos1;
    public Transform bulletPos2;
    public GameObject prefabExplosion;
    

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal"); // the value will be -1, 0, 1 (for left, no input, right)
        float y = Input.GetAxisRaw("Vertical"); /// the value will be -1, 0, 1 (for down, no input, and up)
       
        // now based on the input we compute a direction vector, and we normalize it to get a unit vector
        Vector2 direction = new Vector2 (x, y).normalized;

        // now we calll the funtion that computes and sets the player's postion
        Move(direction);
        if(Input.GetKeyDown("space")) Fire();
    }
     void Move(Vector2 direction) 
    {
        // find the screen limits to the player's movement (left, right, top and bottom edges od the screen)
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        max.x = max.x - 0.225f; // subtract the player sprite half width;
        min.x = min.x + 0.225f; // add the player sprite half width;

        max.y = max.y - 0.225f; // subtract the player sprite half height;
        min.y = min.y + 0.225f; // add the player sprite half height;
        Vector2 pos = transform.position;
        pos += direction * speed * Time.deltaTime;
        // make sure the new position is not outside the screen
        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);
        //Update the player's position;
        transform.position = pos;   
    }
     void Fire()
    {
        GameObject bullet01 = (GameObject)Instantiate(prefabBullet);
        bullet01.transform.position = bulletPos1.position;
        GameObject bullet02 = (GameObject)Instantiate(prefabBullet);
        bullet02.transform.position = bulletPos2.position;
       
    }
     void OnTriggerEnter2D(Collider2D collision)
    {
        // Detect collision of the player ship with an enemy ship, or with an enemy bullet
        if((collision.tag == "EnemyShipTag") || (collision.tag == "EnemyBulletTag"))
        {
            PlayExplosion();
            //Destroy(gameObject);
        }
    }
    void PlayExplosion()
    {
        GameObject explosion = (GameObject)Instantiate(prefabExplosion);    
        explosion.transform.position = transform.position;
    }
}
