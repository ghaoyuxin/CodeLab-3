using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Actor
{
    protected GameObject _gameObject;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody2D;

    //define Actor
    protected Actor(GameObject gameObject) //constructor https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/using-constructors
    {
        _gameObject = gameObject;
        _spriteRenderer = _gameObject.GetComponent<SpriteRenderer>(); ///////////why not use gameObject directly ??
        _rigidbody2D = _gameObject.GetComponent<Rigidbody2D>();
    }

}



public class AIPlayer : Actor
{

    //define AIPlayer
    public AIPlayer(GameObject gameObject) : base(gameObject) { }
}

public class UserControlledPlayer : Actor
{
    //define UserPlayer
    public UserControlledPlayer(GameObject gameObject) : base(gameObject) { }
}