using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIHeuristics
{

}

//questions:
//scope of protected vs public when they are under an abstract class
//scope of private variables when they are under an abstract class
//lambda operator? what does it mean

//HW review：
//virtual - overwrite, abstract - overwrite, 谁是一对儿
//Context._setHumanPlayerTeams()   = new FiniteStateMachine<GameController>(this)
//it's inside the Context, instead of inside the State Machine
//base.Update(); it's the update that's always running
// SetPosition(float x, float y, bool isStartingPosition = false) this is called default parameter, if you don't put the 3rd param in, it's automatically false
//check if
//public bool IsInGame()
//{
//  return _gameControllerStateMachine.CurrentState.GetType() == typeof(InGame);
//  //writing the opposite:
//  if(_gameControllerStateMachine.CurrentState.GetType() == typeof(InGame)) return false;
//    return true;
//}

//Game AI:
//what is? - what actions a game entity should take, based on current conditions
//         - "Sense/Think/Act" cycle
// Constraints of Game AI? 
// - AIs shouldn't optimal, too hard for player
// - need to feel like human
// - must be real time, while the rest of the game is running
// - system should be data-driven, rather than hard coded, so non-technical designers can make use of it

//Decision Tree
// - leaf nodes are "actions"(img 3)
//Event Reactive?
// - Pros: Cons: it might have too many event you have to trigger, too decoupled too grainy
//Finite State Machine?
// - Pros: can program complicated behaviors Cons: all the things are hard-coded, heavy to model
//Hierarchical State Machine?
// - states that contains its own state , whhhhhhhhat even more complicated
// All of the 3 methods have issues: not reusable, not scalable, not accessible to non-technical designers, AI will need to be adjusted a lot so not being able to do that is a big problem

// Graphs : that's what we think might be a better idea
// what is a graph:
// - nodes
// - vertices: directed / undirected 
// - complete
// - cyclic/ a cyclic
// Behavior trees: 
// - graphs made up of nodes and vertices
// - undirected
// - acyclic
//  a depth first tree, - look as deep as we can before going to the next search
//  a breadth first tree, 

// Behavior Tree Nodes: Composite (img 4)
// it's back tracing
// Selector(?): select one of their children, return success as soon as one of their children is successful, false if all children fail
// Sequence(->): like checklists, return success when all their children are successful
// Decorator(菱形): have a signle child and modify the return value of it(change true to false or vice versa), same to ! 
// Action Node (口)：nodes at the outer edges of the tree('leaves'), almost always return true, unless
// Condition Nodes (...): 
//
//Adaotation: System xxxxxxx
//
//Adaptation: Weight Based
//keep set values that inform decision making
//if a startegy is successful, weight that strategy highre in future play; vice versa, lower
//Adaptation: Markov Model, often seen in fighting games decision making
// image in the slide
//Influence Maps:
//have each entity write out their "zone of influence", have that weigh pathfinding and decisionmaking

//Other topics:
//line of sight chasing: - pixel line drawing
//blackboards - will be cover
//pattern movement - will be cover
//flocking - will be cover
//fuzzy logic
//machine learning
