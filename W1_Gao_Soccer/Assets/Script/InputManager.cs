using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager
{
    private float speed = 10;
    private int playerNum = 1;
    public void Update()
    {
        float x = UnityEngine.Input.GetAxis("Horizontal" + playerNum) * speed;
        float y = UnityEngine.Input.GetAxis("Vertical" + playerNum) * speed;
        //assign velocity
        Services.HumanPlayer.rigidbody2D.velocity = new Vector2(x, y);
    }
}
