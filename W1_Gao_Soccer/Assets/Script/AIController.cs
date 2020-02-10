using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AIController
{
    //make 1 AI player
    public void Initialize()
    {
        var AIGameObject = Object.Instantiate(Resources.Load<GameObject>("Actor"));
        new AIPlayer(AIGameObject).SetTeam(false).SetPosition(Random.Range(0, -8.0f), Random.Range(-4.0f, 4.0f)); ////??????? SetTeam not working
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
