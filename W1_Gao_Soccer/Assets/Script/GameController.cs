using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    void Start()
    {
        Services.AIController = new AIController();
        Services.AIController.Initialize();

        //initialize Actors, InputManager

    }

    void Update()
    {
        Services.AIController.Update();

        //run the update for checking input, run the update for Actors

    }
}
