using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Color blueTeamColor, redTeamColor;
    public GameObject ball;
    public int PlayersPerTeam = 2; ////////// why const??? I can't use const, in order for AIController to work

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
