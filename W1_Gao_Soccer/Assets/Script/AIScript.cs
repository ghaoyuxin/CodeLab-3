using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIScript : MonoBehaviour
{
    public Transform ball;
    private Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        var direction = ball.position - gameObject.transform.position;
        direction.Normalize();
        rb.AddForce(direction);
    }
}
