using System.Collections;
using System.Collections.Generic;
using BehaviorTree;
using UnityEngine;

public class SquareController: MonoBehaviour
{

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

    public void BeIdle()
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

    public void ReturnToGate()
    {
        print("returned");
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
        context.BeIdle();

        return true;
    }
}

public class GoToBall : BehaviorTree.Node<SquareController>
{
    private bool isBallInArea;

    public override bool Update(SquareController context)
    {
        context.GoToBall(isBallInArea);

        return true;
    }
}

public class KickBall : BehaviorTree.Node<SquareController>
{
    private bool isBallNearGate;
    public override bool Update(SquareController context)
    {
        context.KickBall(isBallNearGate);
        return true;
    }

    
}

public class ReturnToGate : BehaviorTree.Node<SquareController>
{

    public override bool Update(SquareController context)
    {
        context.ReturnToGate();
        return true;
    }
}
