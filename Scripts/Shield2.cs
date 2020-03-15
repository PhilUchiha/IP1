using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


class Shield2 : MonoBehaviour
{
    public Player player;
    void FixedUpdate()
    {
        transform.position = player.transform.position;
    }

    void OnCollisionEnter2D(Collision2D other) //This is to prevent the moveable character from moving boyond the playable boundaries that are indicated by the "LeftWall" and "RightWall" objects
    {
        switch (other.gameObject.name) //When the character sprite collides with the "LeftWall" or the "RightWall" they will no longer be able to move in the corresponding direction
        {
            case "BigTank(Clone)":
            case "Enemy(Clone)":
            case "SmallTank(Clone)":
                Destroy(gameObject);
                break;
        }
    }



}
