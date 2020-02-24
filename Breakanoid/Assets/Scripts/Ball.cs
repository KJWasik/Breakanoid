using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Configuration parameters
    [SerializeField] Paddle paddle;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;

    // State
    Vector2 paddleToBallDistance;
    bool hasStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        paddleToBallDistance = transform.position - paddle.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (hasStarted != true)
        {
            LockBallToPaddle();
            LaunchBallOnMouseClick();
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddlePos + paddleToBallDistance;
    }

    private void LaunchBallOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(xPush, yPush);
        }
    }
}
