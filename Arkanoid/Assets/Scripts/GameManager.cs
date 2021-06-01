using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Camera mainCam;
    [Range(1, 6)]
    public int BricksRows;
    [Range(5, 15)]
    public int BricksColumns;


    public float brickHeight;
    float brickWidth;
    void Start()
    {
        brickWidth = ((float)13.8 - ((float)0.03* BricksColumns)) / BricksColumns;
        CreateBricks();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateBricks()
    {
        for (int i = 0; i < BricksColumns; i++)
        {
            for (int j = BricksRows; j > 0; j--)
            {
                GameObject Brick = GameObject.CreatePrimitive(PrimitiveType.Cube);
                Brick.transform.localScale = new Vector3((brickWidth), (brickHeight), 1);
                Brick.transform.position = new Vector3(((float)-6.4 + (i * brickWidth) + (i * (float)0.03)), ((float)5.5 - (j * brickHeight)), 0) ;
                Brick.tag = "Brick";
                Brick.name = "Brick" + j + i;
                Renderer rend = Brick.GetComponent<Renderer>();
                switch (j)
                {
                    case 6:
                        rend.material.color = Color.yellow;
                        break;
                    case 1:
                        rend.material.color = Color.red;
                        break;
                    case 2:
                        rend.material.color = Color.magenta;
                        break;
                    case 3:
                        rend.material.color = Color.blue;
                        break;
                    case 4:
                        rend.material.color = Color.cyan;
                        break;
                    case 5:
                        rend.material.color = Color.green;
                        break;                   
                    default:
                        break;
                }

            }
        }
    }
}
