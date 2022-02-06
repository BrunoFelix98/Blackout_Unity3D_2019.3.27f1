using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Finite State Machine/Actions/Stop")]
public class Stop : Ai
{
    public override void Act(FiniteStateMachine fsm)
    {
        if (!fsm.Boss)
        { 
            fsm.GetAnim().SetBool("IsAtDestination", true);
            fsm.GetNavMeshAgent().StopAgent();
        }
        fsm.GetNavMeshAgent().StopAgent();
    }
}
