using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Actor
{
    protected readonly GameObject GameObject;
    private readonly SpriteRenderer _spriteRenderer; ////////why using private not protected
    public readonly Rigidbody2D rigidbody2D;
    private bool _isBlueTeam = false;

    #region Lifecycle Management
    //define Actor
    protected Actor(GameObject gameObject) //constructor https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/using-constructors
    {
        this.GameObject = gameObject; // GameObject is a monobehavior, not a C# thing, so I need to create a gameobject that can have the spriterenderer and rigidbody etc.
        _spriteRenderer = this.GameObject.GetComponent<SpriteRenderer>(); ///////////why not use gameObject directly ??
        rigidbody2D = this.GameObject.GetComponent<Rigidbody2D>();
    }

    public abstract void Update(); ////////why using public not protected, this means, the class Actor or its subclass must provide an implementation for "Update" function
    public void Destroy()
    {
        UnityEngine.Object.Destroy(GameObject);
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
        GameObject.transform.position = new Vector3(x, y); // z is default = 0
        return this;
    }

    // protected Actor ApplyDirection(Vector3 target) ////////can I set it to protected, is this a good way of writing this?
    // {
    // }

    #endregion

}



public class AIPlayer : Actor
{
    //define AIPlayer
    public AIPlayer(GameObject gameObject) : base(gameObject) { } //constructor
    //define AIPlayer behavior
    public override void Update()
    {
        var direction = Services.GameController.ball.transform.position - GameObject.transform.position;
        direction.Normalize();
        rigidbody2D.AddForce(direction);

    }
}

public class HumanPlayer : Actor
{
    //define HumanPlayer
    public HumanPlayer(GameObject gameObject) : base(gameObject) { } //constructor
    //define HumanPlayer behavior
    public override void Update() { }
}