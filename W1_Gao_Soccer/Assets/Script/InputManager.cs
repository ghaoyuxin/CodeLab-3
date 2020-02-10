using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager
{
    public float speed = 20;
    private int playerNum = 1;
    void Update()
    {
        float x = UnityEngine.Input.GetAxis("Horizontal" + playerNum) * speed;
        float y = UnityEngine.Input.GetAxis("Vertical" + playerNum) * speed;
        //assign velocity
        Services.Actor._rigidbody2D.velocity = new Vector2(x, y);
    }
}
