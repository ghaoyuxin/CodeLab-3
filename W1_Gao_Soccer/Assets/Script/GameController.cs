using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Color blueTeamColor, redTeamColor;
    public GameObject ball;
    public int playersPerTeam = 2; ////////// why const??? I can't use const, in order for AIController to work
    private Actor _humanPlayer;

    void Start()
    {

        Services.GameController = this;
        Services.AIController = new AIController();

        Services.AIController.Initialize();
        Services.InputManager = new InputManager();

        //make HumanPlayer
        var playerGameObject = Instantiate(Resources.Load<GameObject>("Actor")); // <GameObject> casting type
        Services.HumanPlayer = (HumanPlayer)new HumanPlayer(playerGameObject).SetTeam(true).SetPosition(1, 0);

    }

    void Update()
    {
        //run the update for checking input, run the update for Actors
        Services.AIController.Update();
        Services.InputManager.Update();

    }
}
