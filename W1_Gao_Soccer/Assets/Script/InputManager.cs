using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 20;
    public int playerNum = 1;
    void Start()
    {
        //get whatever player or AIplayer??? maybe I don't need this
        rb = GetComponent<Rigidbody2D>();

    }
    void Update()
    {
        float x = Input.GetAxis("Horizontal" + playerNum) * speed;
        float y = Input.GetAxis("Vertical" + playerNum) * speed;
        rb.velocity = new Vector2(x, y);
    }
}
