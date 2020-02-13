using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AIController
{
    //make a few AI player
    private List<Actor> _AIPlayers;
    public void Initialize()
    {
        _AIPlayers = new List<Actor>();
        _CreateAIs();
    }

    private void _CreateAIs()
    {
        //make red team AI
        for (var i = 0; i < GameController.PlayersPerTeam; i++)
        {
            var AIGameObject = Object.Instantiate(Resources.Load<GameObject>("Actor"));
            _AIPlayers.Add(new AIPlayer(AIGameObject).SetTeam(false).SetPosition(Random.Range(0, -7.0f), Random.Range(-4.0f, 4.0f)));
        }

        //make blue team AI, except for HumanPlayer
        for (var i = 0; i < GameController.PlayersPerTeam - 1; i++)
        {
            var AIGameObject = Object.Instantiate(Resources.Load<GameObject>("Actor"));
            _AIPlayers.Add(new AIPlayer(AIGameObject).SetTeam(true).SetPosition(Random.Range(0, 7.0f), Random.Range(-4.0f, 4.0f)));
        }

    }

    public void Update()
    {
        foreach (var AIPlayer in _AIPlayers)
        {
            AIPlayer.Update();
        }

    }

}
