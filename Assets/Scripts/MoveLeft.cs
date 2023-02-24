using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
  public float speed = 0;
  private PlayerController playerControllerScript;
  public int leftBound = -10;

    void Start()
    {
     playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }


    void Update()
    {
        if (!playerControllerScript.gameOver)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        else {
            transform.Translate(Vector3.left * 0);
        }
        if (gameObject.CompareTag("Obstacle") && transform.position.x < leftBound)
        {
            Destroy(gameObject);
        }
        if (!playerControllerScript.isOnGround)
        {
            speed = 30;
        }
        if (Input.GetKey(KeyCode.RightArrow) && playerControllerScript.isOnGround && !playerControllerScript.gameOver)
        {
            speed = 50;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) && !playerControllerScript.gameOver)
        {
            speed = 30;
        }
        if (speed == 30 && !playerControllerScript.gameOver)
        {
            playerControllerScript.score += 1;
        } else if (speed == 50 && !playerControllerScript.gameOver)
        {
            playerControllerScript.score += 2;
        }
    }
}
