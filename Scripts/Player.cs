using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


class Player : MonoBehaviour
{
    public KeyCode moveLeftKey = KeyCode.A;
    public KeyCode moveRightKey = KeyCode.D;
    public KeyCode moveUpKey = KeyCode.W;
    public KeyCode moveDownKey = KeyCode.S;
    public KeyCode shootKey = KeyCode.Space;
    bool canMoveLeft = true;
    bool canMoveRight = true;
    bool canMoveUp = true;
    bool canMoveDown = true;
    public Bullet bulletTemplate;
    public NegativeBullet negativebulletTemplate;
    public Shield2 shieldTemplate;

    bool negativebullet = false;

    public float speed = 1f;
    float directionx = 0.0f;
    float directiony = 0.0f;

    public Sprite sprite; //This will be the character's default sprite
    public Sprite up; //This will be the character's sprite when moving up
    public Sprite forward; //This will be the character's sprite when moving forward

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // we are accessing the SpriteRenderer that is attached to the Gameobject
            spriteRenderer.sprite = sprite; // set the sprite to be the default sprite
    }
    void FixedUpdate()
    {
        Vector3 position = transform.localPosition;
        position.x += speed * directionx;
        position.y += speed * directiony;
        transform.localPosition = position;


        if (Input.GetKey(KeyCode.W)) //If the "W" key is pressed
        {
            UpSprite(); // call method to change to the "Up" sprite
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ForwardSprite();
        }
        else if (Input.GetKey(KeyCode.A))
        {
            ForwardSprite(); //This uses the same method as the forward sprite as the character is flipped when the "A" is pressed within the "Update" method
        }
        else
        {
            spriteRenderer.sprite = sprite;
        }
    }

    void UpSprite()
    {
        spriteRenderer.sprite = up;
    }

    void ForwardSprite()
    {
        spriteRenderer.sprite = forward;
    }

    private void LateUpdate()
    {
        bool isAPressed = Input.GetKey(moveLeftKey);
        bool isDPressed = Input.GetKey(moveRightKey);

        if (isAPressed)
        {
            negativebullet = true;
        }

        if (isDPressed)
        {
            negativebullet = false;
        }
    }

    void Update()
    {
        bool isAPressed = Input.GetKey(moveLeftKey);
        bool isDPressed = Input.GetKey(moveRightKey);
        bool isWPressed = Input.GetKey(moveUpKey);
        bool isSPressed = Input.GetKey(moveDownKey);

        if (isAPressed && canMoveLeft)
        {
            directionx = -1.0f;
            transform.eulerAngles = new Vector3(0, 180, 0); // Flipped
        }
        else if (isDPressed && canMoveRight)
        {
            directionx = 0.8f;
            transform.eulerAngles = new Vector3(0, 0, 0); // Normal
        }
        else
        {
            directionx = 0.0f;
        }

        if (isWPressed && canMoveUp)
        {
            directiony = 0.8f;
        }
        else if (isSPressed && canMoveDown)
        {
            directiony = -1.0f;
        }
        else
        {
            directiony = 0.0f;
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {           
            if(negativebullet == true)
            {
                NegativeShoot();
            }
            else
            {
                Shoot();
            }
        }
    }

    public void Shoot() //Method for spawning the Bullet game object
    {      
        Bullet bulletClone = Instantiate(bulletTemplate); //This clones the template game object when the game is first run
        bulletClone.transform.position = transform.position; //The Bullet clone will move to the position of the Bullet spawner
        bulletClone.gameObject.SetActive(true); //Activates the Bullet clone in game
    }

    public void NegativeShoot()
    {
        NegativeBullet negativebulletClone = Instantiate(negativebulletTemplate); //This clones the template game object when the game is first run

        negativebulletClone.transform.position = transform.position; //The NegativeBullet clone will move to the position of the NegativeBullet spawner
        negativebulletClone.gameObject.SetActive(true); //Activates the NegativeBullet clone in game
    }

    public void Shield()
    {
        Shield2 shieldClone = Instantiate(shieldTemplate); 

        shieldClone.transform.position = transform.position; 
        shieldClone.gameObject.SetActive(true); 
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        switch (other.gameObject.name)
        {
            case "Enemy(Clone)":
            case "BigTank(Clone)":
            case "SmallTank(Clone)":
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                break;

            case "ShieldPickup": //Calls the Shield() method when the player collects the shield pickup item
                Shield();
                break;
        }
    }


 
}
