using System.Collections;
using System.Collections.Generic;
using BehaviorTree;
using UnityEngine;

public class SquareController: MonoBehaviour
{
    private float _speed = 0.1f;
    public bool hungry;

    private BehaviorTree.Tree<SquareController> _tree;

    private void Start()
    {
        var ballInArea = new Tree<SquareController> //Tree<T>()
        (
            new Sequence<SquareController>
            (
                new IsBallInArea(),
                new GoToBall()
            )
        );

        var ballNearGate = new Tree<SquareController>
        (
            new Selector<SquareController>
            (
                new Sequence<SquareController>
                    (
                    new IsBallNearGate(),
                        new KickBall()
                    ),
                new ReturnToGate()
                
            )
        );

        _tree = new Tree<SquareController>
        (
            new Selector<SquareController>
            (
                ballInArea,
                ballNearGate,
                new Idling()
            )
        );
    }

    private void Update()
    {
        _tree.Update(this);
    }

    public void Idling()
    {
        print("Idling");
        
    }

    public void GoToBall(bool isBallInArea)
    {
        print("going to ball");

    }

    public void KickBall(bool isBallNearGate)
    {
        print("kicked ball");
    }
    

}

public class IsBallInArea : BehaviorTree.Node<SquareController>
{
    public override bool Update(SquareController context)
    {
        return Input.GetMouseButton(0);//replace this
    }
}

public class IsBallNearGate : BehaviorTree.Node<SquareController>
{

    public override bool Update(SquareController context)
    {
        return Input.GetMouseButton(1);//replace this
    }
}


public class Idling : BehaviorTree.Node<SquareController>
{
    public override bool Update(SquareController context)
    {
        context.Shake();

        return true;
    }
}

public class GoTowardsMouse : BehaviorTree.Node<SquareController>
{
    private bool towards;

    public GoTowardsMouse(bool towards)
    {
        this.towards = towards;
    }

    public override bool Update(SquareController context)
    {
        context.GoTowardsMouse(towards);

        return true;
    }
}

public class BecomeHungry : BehaviorTree.Node<SquareController>
{
    public override bool Update(SquareController context)
    {
        context.hungry = true;

        return true;
    }
}
