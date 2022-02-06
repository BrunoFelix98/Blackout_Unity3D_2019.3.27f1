using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Finite State Machine/Transition")]
public class Transition : ScriptableObject
{
    [SerializeField]
    private Condition decision;
    [SerializeField]
    private Ai action;
    [SerializeField]
    private State TargetState;

    public bool isTriggerd(FiniteStateMachine fsm)
    {
        return decision.test(fsm);
    }
    public Ai getAction()
    {
        return action;
    }
    public State GetTargetState()
    {
        return TargetState;
    }
}