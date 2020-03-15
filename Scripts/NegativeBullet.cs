using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NegativeBullet : Bullet //This inherits the "Bullet" script but will have the public speed set to move along the negative x-axis
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        switch (other.gameObject.name)
        {
            case "Kill Floor L":
                Destroy(gameObject);
                break;

            case "BigTank(Clone)":
                Destroy(gameObject);
                break;

            case "SmallTank(Clone)":
            case "Enemy(Clone)":
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
