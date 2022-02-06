using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Actions/Find Buddy")]
public class FindBuddyAction : Ai
{
    public override void Act(FiniteStateMachine fsm)
    {
        if (!fsm.GetAnim().GetCurrentAnimatorStateInfo(0).IsName("GettingHit"))
        {
            if (!fsm.GetAnim().GetCurrentAnimatorStateInfo(0).IsName("Dead"))
            {
                fsm.GetNavMeshAgent().agent.isStopped = false;
                fsm.GetNavMeshAgent().FindBuddy();
            }
            else
            {
                fsm.GetNavMeshAgent().agent.isStopped = true;
            }
        }
        else
        {
            fsm.GetNavMeshAgent().agent.isStopped = true;
        }
    }
}