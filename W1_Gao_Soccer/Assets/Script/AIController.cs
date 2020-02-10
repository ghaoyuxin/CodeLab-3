using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AIController
{

    public void Initialize()
    {
        var playerGameObject = Object.Instantiate(Resources.Load<GameObject>("Actor"));
        new AIPlayer(playerGameObject).SetTeam(false).SetPosition(Random.Range(0, -0.8f), Random.Range(-4.0f, 4.0f)); ////??????? not working
    }

    // private void _CreateAIs()
    // {
    //     _AIs = new List<Actor>();
    //     for (var i = 0; i < Services.GameController.PlayersPerTeam; i++)
    //         Object.Instantiate(Resources.Load<GameObject>("Actor"));
    //     _AIs.Add(_AIs.SetTeam(false).SetPosition(-1, 0))
    // }

    public void Update()
    {


    }

}
