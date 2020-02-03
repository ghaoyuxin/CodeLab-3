using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 20;
    public int score;
    public int playerNum = 1;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }
    void Update()
    {
        float x = Input.GetAxis("Horizontal" + playerNum) * speed; //Use Input.GetAxisRaw to get whole number values 0,1
        float y = Input.GetAxis("Vertical" + playerNum) * speed;
        rb.velocity = new Vector2(x, y);
    }
}
