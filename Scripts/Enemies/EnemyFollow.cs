using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// remember to tag the player

public class EnemyFollow : MonoBehaviour
{

    public float speed;
    public Transform target;
    public Bullet Bullet;
    int scorevalue = 2;

    void Update()
    {
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }

    public void OnCollisionEnter2D(Collision2D other)
    {

        switch(other.gameObject.name)
        {
            case "Bullet":
            case "Bullet(Clone)":
            case "NegativeBullet(Clone)":
                Destroy(gameObject);
                Bullet.IncreaseScore(scorevalue);
                break;

            case "Shield(Clone)":
                Destroy(gameObject);
                Bullet.EnemySpawner.SpawnEnemy();

                break;
            case "EnemyFastWall":
                EnemyFastMove();
                break;
        }
    }

    public void EnemyFastMove()
    {
        Vector3 position = transform.localPosition;
        position.x -= speed;
        transform.localPosition = position; //The Enemy will move in a straight line along the negative x-axis when this method is called
    }
}
