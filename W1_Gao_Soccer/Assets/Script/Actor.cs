﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Actor
{
    protected GameObject _gameObject;
    private SpriteRenderer _spriteRenderer; ////////why using private not protected
    public Rigidbody2D _rigidbody2D;
    private bool _isBlueTeam = false;

    #region Lifecycle Management
    //define Actor
    protected Actor(GameObject gameObject) //constructor https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/using-constructors
    {
        _gameObject = gameObject;
        _spriteRenderer = _gameObject.GetComponent<SpriteRenderer>(); ///////////why not use gameObject directly ??
        _rigidbody2D = _gameObject.GetComponent<Rigidbody2D>();
    }

    public abstract void Update(); ////////why using public not protected, this means, the class Actor or its subclass must provide an implementation for "Update" function
    public void Destroy()
    {
        UnityEngine.Object.Destroy(_gameObject);
    }
    #endregion

    #region Core Functions
    public Actor SetTeam(bool blueTeam) ///////why public?
    {
        _isBlueTeam = blueTeam;
        _spriteRenderer.color = _isBlueTeam ? Services.GameController.blueTeamColor : Services.GameController.redTeamColor;
        return this;
    }

    public Actor SetPosition(float x, float y) ////////why public?
    {
        _gameObject.transform.position = new Vector3(x, y); // z is default = 0
        return this;
    }

    // protected Actor ApplyDirection(Vector3 target) ////////can I set it to protected, is this a good way of writing this?
    // {
    //     var direction = target - _gameObject.transform.position;
    //     direction.Normalize();
    //     _rigidbody2D.AddForce(direction);
    //     return this;
    // }

    #endregion

}



public class AIPlayer : Actor
{
    //define AIPlayer
    public AIPlayer(GameObject gameObject) : base(gameObject) { } //constructor
    //AIPlayer follows the ball, define behavior
    public override void Update()
    {
        var direction = Services.GameController.ball.transform.position - _gameObject.transform.position;
        direction.Normalize();
        _rigidbody2D.AddForce(direction);

    }
}

public class HumanPlayer : Actor
{
    //define UserPlayer
    public HumanPlayer(GameObject gameObject) : base(gameObject) { }
    public override void Update()
    {

    }
}