using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    float speedEnemyBullet;
    bool isReady;
    Vector2 _direction;
     void Awake()
    {
        speedEnemyBullet = 5f;
        isReady = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void SetDirection(Vector2 direction)
    {
        _direction = direction.normalized;
        isReady = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (isReady)
        {
            // get the bullet's current position
            Vector2 position = transform.position;
            //Compute the bullet's new postion
            position += _direction * speedEnemyBullet * Time.deltaTime;
            // Update the bullet's postion
            transform.position = position;
            // we need to remove the bullet from our game\
            // if the bullet goes outside the screen
            Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
            Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

            if ((transform.position.x < min.x) || (transform.position.x > max.x) || (transform.position.y < min.y) || (transform.position.y > max.y))
            {
                Destroy(gameObject);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Detect collsion of an enemy's bullet with the player ship
        if(collision.tag == "PlayerShipTag")
        {
            // Destroy this enemy's bullet
            Destroy(gameObject);
        }
    }
}
