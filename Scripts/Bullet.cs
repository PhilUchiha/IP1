using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    public float speed = 1.0f;
    public KeyCode moveLeftKey = KeyCode.A;
    public SmallTank smalltankTemplate;
    public BigTank BigTank;
    public EnemySpawner EnemySpawner;
    public EnemySpawner2 EnemySpawner2;
    public EnemySpawner3 EnemySpawner3;
    public Text ScoreLabel; //This script will be linked to the score textbox created in Unity
    public int score = 0; //Score has an initial value of 5
    void FixedUpdate()
    {
        {
            Vector3 position = transform.localPosition;
            position.x += speed;
            transform.localPosition = position; //Each bullet spawned will travel to the right along the x-axis with a fixed speed

        }
    }
    public void IncreaseScore(int points) //Score is increased in relation to the amount of points awarded; this will update the score textbox to display the total points acquired by the player
    {
        score += points;
        ScoreLabel.text = score.ToString();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        switch (other.gameObject.name)
        {
            case "Kill Floor R":
                Destroy(gameObject); //Destroys the game object when it collides with an enemy or the right 'kill floor', this stops the bullet object from existing when it leaves the player's screen
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
