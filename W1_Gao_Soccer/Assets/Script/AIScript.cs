using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIScript : MonoBehaviour
{
    private Vector2 ball;
    private Rigidbody2D rb;
    private void Start()
    {
        ball = GameObject.FindWithTag("Ball").transform.position;
        rb = GetComponent<Rigidbody2D>();
        print(ball);
    }

    private void Update()
    {
        rb.velocity = new Vector2(ball.x, ball.y);
    }
}
