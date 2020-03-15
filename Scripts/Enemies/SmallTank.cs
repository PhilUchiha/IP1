using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SmallTank : MonoBehaviour
{
    public float speed = 1.0f;
    public EnemySpawner EnemySpawner;
    public EnemySpawner2 EnemySpawner2;
    public EnemySpawner3 EnemySpawner3;
    public Bullet Bullet;
    int scorevalue = 5;
    void Start() 
    {

    }
    void FixedUpdate()
    {
        Vector3 position = transform.localPosition;
        position.x -= speed;
        transform.localPosition = position; //The small tank enemy travels towards the left along the x axis at a fixed speed
    }
    private void OnCollisionEnter2D(Collision2D other) //The "Small Tank" enemy is destroyed when it collides with the "Bullet" game object
    {
        switch (other.gameObject.name)
        {
            case "Bullet":
            case "Bullet(Clone)":
            case "NegativeBullet(Clone":
                Destroy(gameObject);
                Bullet.IncreaseScore(scorevalue);
                break;

            case "EnemyKillWall":
            case "Shield(Clone)":
                Destroy(gameObject);
                if (Random.Range(0, 100) < 66)
                {
                    if (Random.Range(0, 100) < 50)
                    {
                        EnemySpawner.SpawnEnemy();
                    }
                    else
                    {
                        EnemySpawner2.SpawnEnemy();
                    }
                }
                else
                {
                    EnemySpawner3.SpawnEnemy();
                }
                break;
        }
    }
}
