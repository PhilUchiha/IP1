using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner4 : EnemySpawner
{
    public Bullet bullet;

    private void Start()
    {
        gameObject.SetActive(false);
    }
    private void Update()
    {
        if(bullet.score >= 100)
        {
            gameObject.SetActive(true);
        }
    }
}
