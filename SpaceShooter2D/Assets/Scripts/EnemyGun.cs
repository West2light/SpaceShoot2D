using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    public GameObject prefabEnemyBullet;

    // Start is called before the first frame update
    void Start()
    {
        // fire an enemy bullet after 1 second
        Invoke("FireEnemyBullet", 1f);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void FireEnemyBullet()
    {
        // get reference to the player's ship
        GameObject playerShip = GameObject.Find("PlayerGO");
        if (playerShip != null) // if the player is not dead
        {
            // Instantiate an emeny bullet
            GameObject bulletEnemy = (GameObject)Instantiate(prefabEnemyBullet);
            // set the bullet's initial position
            bulletEnemy.transform.position = transform.position;
            //Compute the bullet's direction towards the player's ship 
            Vector2 direction = playerShip.transform.position - bulletEnemy.transform.position;
            //set the bullet's direction
            bulletEnemy.GetComponent<EnemyBulletController>().SetDirection(direction);

        }
    }
}

