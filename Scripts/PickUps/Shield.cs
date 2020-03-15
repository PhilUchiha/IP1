using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D other)
    {
        switch (other.gameObject.name)
        {
            case "Enemy(Clone)":
            case "BigTank(Clone)":
            case "SmallTank(Clone)":
                Destroy(gameObject);
                break;
        }
    }
}
