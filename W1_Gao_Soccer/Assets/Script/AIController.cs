using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AIController
{
    //make a few AI player
    private List<Actor> _aiPlayers;
    public void Initialize()
    {
        _aiPlayers = new List<Actor>();
        _CreateAIs();
    }

    private void _CreateAIs()
    {
        //make red team AI
        for (var i = 0; i < Services.GameController.playersPerTeam; i++)
        {
            var aiGameObject = Object.Instantiate(Resources.Load<GameObject>("Actor"));
            _aiPlayers.Add(new AIPlayer(aiGameObject).SetTeam(false)
                .SetPosition(Random.Range(0, -7.0f), Random.Range(-4.0f, 4.0f)));
        }

        //make blue team AI, except for HumanPlayer
        for (var i = 0; i < Services.GameController.playersPerTeam - 1; i++)
        {
            var aiGameObject = Object.Instantiate(Resources.Load<GameObject>("Actor"));
            _aiPlayers.Add(new AIPlayer(aiGameObject).SetTeam(true)
                .SetPosition(Random.Range(0, 7.0f), Random.Range(-4.0f, 4.0f)));
        }
    }

    public void Update()
    {
        foreach (var aiPlayer in _aiPlayers)
        {
            aiPlayer.Update();
        }

    }

    public void Destory()
    {
        foreach (var actor in _aiPlayers)
        {
            actor.Destroy();
        }
    }

}
