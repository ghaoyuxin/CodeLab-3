using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Color blueTeamColor, redTeamColor;

    void Start()
    {
        Services.AIController = new AIController();
        Services.AIController.Initialize();

        //initialize Actors, //load prefab for player, //InputManager

    }

    void Update()
    {
        Services.AIController.Update();



        //run the update for checking input, run the update for Actors

    }
}
