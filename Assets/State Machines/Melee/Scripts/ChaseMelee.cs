using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Actions/ChaseMelee")]
public class ChaseMelee : Ai
{
    public override void Act(FiniteStateMachine fsm)
    {
        fsm.GetAnim().SetBool("IsAtDestination", false);

        fsm.cState = ChaseState.ChaseStateMelee;
        if (!fsm.GetAnim().GetCurrentAnimatorStateInfo(0).IsName("GettingHit"))
        {
            if (!fsm.GetAnim().GetCurrentAnimatorStateInfo(0).IsName("Dead"))
            {
                fsm.GetNavMeshAgent().agent.isStopped = false;
                fsm.GetNavMeshAgent().GoToTarget();
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
