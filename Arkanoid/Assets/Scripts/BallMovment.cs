using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovment : MonoBehaviour
{
    bool isMoving;
    [SerializeField]Vector3 direction;
    public float speed;
    public float speedToAddInHit;
    public GameObject Player;
    public float distanceToPlayer;
    public Rigidbody ballRB;
    void Start()
    {
        InitBall();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && isMoving == false)
        {
            isMoving = true;
        }

        if(isMoving == false)
        {
            this.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y + distanceToPlayer, 0);
        }
        if (isMoving == true)
        {
            this.transform.position += (direction * speed * Time.deltaTime);
        }


    }

    private void OnCollisionEnter(Collision collision)
    {               
        if (collision.transform.tag == "Player" || collision.transform.tag == "Roof")
        {
            direction.y = direction.y * -1;
            speed += speedToAddInHit;
        }
        if (collision.transform.tag == "Wall")
        {
            direction.x = direction.x * -1;
            speed += speedToAddInHit;
        }
        if (collision.transform.tag == "Brick")
        {
            float BrickHidth = collision.transform.localScale.x;
            float BrickHigh = collision.transform.localScale.y;
            bool leftCol = false;
            bool rightCol = false;
            bool upperCol = false;
            bool downCol = false;
            //s chequea desde donde colisiona
            {
                if (this.transform.position.x < collision.transform.position.x - (BrickHidth / 2))
                {
                    leftCol = true;
                }
                if (this.transform.position.x > collision.transform.position.x + (BrickHidth / 2))
                {
                    rightCol = true;
                }
                if (this.transform.position.y < collision.transform.position.y - (BrickHigh / 2))
                {
                    downCol = true;
                }
                if (this.transform.position.y > collision.transform.position.y + (BrickHigh / 2))
                {
                    upperCol = true;
                }
            }
            if ((upperCol || downCol) && !leftCol && !rightCol)
            {
                direction.y = direction.y * -1;
            }
            if ((upperCol || downCol) && (leftCol || rightCol))
            {
                direction.y = direction.y * -1;
                if (direction.x == 0)
                {
                    if (leftCol)
                    {
                        direction.x = -0.5f;
                    }
                    if(rightCol)
                    {
                        direction.x = 0.5f;
                    }
                }
                else 
                {
                    direction.x = direction.x * -1;
                }
            }

            if ((leftCol || rightCol) && !upperCol && !downCol)
            {
                direction.x = direction.x * -1;
            }
            Destroy(collision.gameObject);
        }
    }

    void InitBall()
    {
        isMoving = false;
        direction = Vector3.up; 
    }
}
