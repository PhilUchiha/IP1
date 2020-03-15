using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public BigTank bigtankTemplate;
    public EnemyFollow enemyfollowTemplate;
    public SmallTank smalltankTemplate;

    private void Start()
    {
            SpawnEnemyFollow();
    }
    public void SpawnEnemyFollow() //To spawn the "EnemyFollow" enemy type
    {
        EnemyFollow enemyfollowClone = Instantiate(enemyfollowTemplate); //Creates a clone of the "EnemyFollow" game object

        enemyfollowClone.transform.position = transform.position; //Moves the "EnemyFollow" to spawn in the position of the "EnemySpawner" object
        enemyfollowClone.gameObject.SetActive(true); //Sets the "EnemyFollow" game object to be active when the method is called
    }

    public void SpawnBigTank() //To Spawn the "BigTank" enemy type
    {
        BigTank bigtankClone = Instantiate(bigtankTemplate); //Creates a clone of the "BigTank" game object

        bigtankClone.transform.position = transform.position; //Moves the "BigTank" to spawn in the position of the "EnemySpawner" object
        bigtankClone.gameObject.SetActive(true); //Sets the "BigTank" game object to be active when the method is called
    }

    public void SpawnSmallTank()
    {
        SmallTank smalltankClone = Instantiate(smalltankTemplate); //Creates a clone of the "SmallTank" game object

        smalltankClone.transform.position = transform.position; //Moves the "SmallTank" to spawn in the position of the "EnemySpawner" object
        smalltankClone.gameObject.SetActive(true); //Sets the "SmallTank" game object to be active when the method is called
    }
public void SpawnEnemy()
    {
        if (Random.Range(0, 100) < 85) //Provides a random range that makes it so the spawner has a 50% chance of spawning either the "BigTank" or "EnemyFollow" enemy type when the method is called
        {
            if(Random.Range(0, 100) < 70)
            {
                SpawnEnemyFollow();
            }
            else
            {
                SpawnSmallTank();
            }
        }
        else
        {
            SpawnBigTank();
        }
    }
}
