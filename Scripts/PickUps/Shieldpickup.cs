using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shieldpickup : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other) //This is to prevent the moveable character from moving boyond the playable boundaries that are indicated by the "LeftWall" and "RightWall" objects
    {
        switch (other.gameObject.name) //When the character sprite collides with the "LeftWall" or the "RightWall" they will no longer be able to move in the corresponding direction
        {
            case "EnemyKillWall":
                case "Player":
                Destroy(gameObject);
                break;

        }
    }
}
