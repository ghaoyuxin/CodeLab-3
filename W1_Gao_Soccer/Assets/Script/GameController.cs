using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Color blueTeamColor, redTeamColor;
    public GameObject ball;
    public int playersPerTeam = 2; //????I can't use const, in order for AIController to work
    private Actor _humanPlayer;
    private FiniteStateMachine<GameController> _gameStateController;
    public GameObject start, main, gameOver;

    private void Awake()
    {
        Services.GameController = this;

        Services.InputManager = new InputManager();
        
        _gameStateController = new FiniteStateMachine<GameController>(this);
        _gameStateController.TransitionTo<TitleScreen>();
    }

    private void Update()
    {
        //run the update for checking input, run the update for Actors
        _gameStateController.Update();

    }
    
    //setup structure of state
    private class GameState : FiniteStateMachine<GameController>.State
    {
        public override void OnEnter() // when does this happen??
        {
            Context.start.SetActive(false);
            Context.main.SetActive(false);
            Context.gameOver.SetActive(false);
        }
    }
    
    //define states
    private class TitleScreen : GameState
    {
        public override void OnEnter()
        {
            base.OnEnter();
            
            Context.start.SetActive(true);
        }

        public override void Update()
        {
            base.Update();

            if (Input.GetKeyDown(KeyCode.Space))
            {
                TransitionTo<InGame>();
            }
        }
    }

    private class InGame : GameState
    {
        public override void OnEnter()
        {
            base.OnEnter();

            Context.main.SetActive(true);
            
            //make HumanPlayer
            var playerGameObject = Instantiate(Resources.Load<GameObject>("Actor"));
            Services.HumanPlayer = (HumanPlayer)new HumanPlayer(playerGameObject).SetTeam(true).SetPosition(1, 0);
            
            Services.AIController = new AIController();
            Services.AIController.Initialize();
        }

        public override void Update()
        {
            base.Update();
            
            Services.InputManager.Update();
            Services.AIController.Update();
        }
    }
}
