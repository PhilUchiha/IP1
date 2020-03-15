using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG1 : MonoBehaviour
{
    public BG1 BG;
    public float speed = 0.05f;
    public Spawner spawner;

    void FixedUpdate()
    {
        Vector3 position = transform.localPosition;
        position.x += -speed;
        transform.localPosition = position;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        switch (other.gameObject.name)
        {
            case "BG_Destroyer":
                transform.position = spawner.transform.position;
                break;
        }
            
    }
}
