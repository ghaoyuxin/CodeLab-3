using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AIController
{
    //make a few AI player
    private List<Actor> _AIs;
    public void Initialize()
    {
        _AIs = new List<Actor>();
        _CreateAIs();
    }

    private void _CreateAIs()
    {
        for (var i = 0; i < Services.GameController.PlayersPerTeam; i++)
        {
            var AIGameObject = Object.Instantiate(Resources.Load<GameObject>("Actor"));
            _AIs.Add(new AIPlayer(AIGameObject).SetTeam(false).SetPosition(Random.Range(0, -8.0f), Random.Range(-4.0f, 4.0f)));
        }


    }

    public void Update()
    {


    }

}
