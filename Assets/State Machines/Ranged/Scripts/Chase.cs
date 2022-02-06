using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Actions/Chase")]
public class Chase : Ai
{
    public override void Act(FiniteStateMachine fsm)
    {
   
        fsm.cState = ChaseState.ChaseState;
        fsm.GetAnim().SetBool("IsAtDestination", false);
        fsm.GetAnim().SetBool("IsInRange", false);
        fsm.GetAnim().SetBool("CanAttackPlayer", false);
        fsm.GetAnim().SetBool("CanSeePlayer", true);

        if (!fsm.GetAnim().GetCurrentAnimatorStateInfo(0).IsName("PreparingAttack"))
        {
            if (!fsm.GetAnim().GetCurrentAnimatorStateInfo(0).IsName("GettingHit"))
            {
                if (!fsm.GetAnim().GetCurrentAnimatorStateInfo(0).IsName("Dead"))
                {
                    fsm.GetNavMeshAgent().agent.isStopped = false;
                    fsm.GetNavMeshAgent().transform.LookAt(fsm.GetNavMeshAgent().GetTarget());
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
        else
        {
            fsm.GetNavMeshAgent().agent.isStopped = true;

        }
        if (fsm.GetAnim().GetBool("CanSeePlayer") == true && fsm.GetAnim().GetCurrentAnimatorStateInfo(0).IsName("Walking"))
        {
            fsm.GetNavMeshAgent().agent.isStopped = false;
        }
    }
} //PERFECT