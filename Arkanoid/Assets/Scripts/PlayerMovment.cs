using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public float speed;
    public int lives;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < 6)
        {
            transform.position += Vector3.right * speed * Time.fixedDeltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > -6)
        {
            transform.position += Vector3.left * speed * Time.fixedDeltaTime;
        }
    }

    void ReduceLives()
    {
        lives--;
        if (lives < 0)
        {
            EmdGame();
        }
    }
    void EmdGame()
    {

    }
}
