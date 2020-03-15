using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BigTank : EnemyFollow //This script inherits the command lines from the "EnemyFollow" script as it behaves in a similar motion
{
    public SmallTank smalltankTemplate;
    int scorevalue = 5;
    private void OnCollisionEnter2D(Collision2D other)
    {
        switch (other.gameObject.name)
        {
            case "Bullet":
            case "Bullet(Clone)":
            case "NegativeBullet(Clone)":
            case "Shield(Clone)":
                Destroy(gameObject);
                SpawnSmallTank();
                Bullet.IncreaseScore(scorevalue);
                break;
        }
    }

    private void SpawnSmallTank()
    {
        SmallTank smalltankClone = Instantiate(smalltankTemplate); //Creates a clone of the "SmallTank" game object

        smalltankClone.transform.position = transform.position; //Moves the "SmallTank" to spawn in the position of the "BigTank" object
        smalltankClone.gameObject.SetActive(true); //Sets the "SmallTank" game object to be active when the method is called
    }
}
