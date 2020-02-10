using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController
{
    private Transform ball;
    private Transform enemy;
    private Rigidbody2D rb;
    public void Initialize()
    {
        ball = GameObject.FindWithTag("Ball").transform;
        //can I just get one AI player's transform???
        enemy = GameObject.FindWithTag("Enemy").transform;
        rb = enemy.gameObject.GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        var direction = ball.position - enemy.position;
        direction.Normalize();
        rb.AddForce(direction);

    }

}
