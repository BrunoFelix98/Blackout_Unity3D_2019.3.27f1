using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Actions/Attack Melee")]
public class AttackMelee : Ai
{
    public override void Act(FiniteStateMachine fsm)
    {

        if (!fsm.GetAnim().GetCurrentAnimatorStateInfo(0).IsName("GettingHit"))
        {
            if (!fsm.GetAnim().GetCurrentAnimatorStateInfo(0).IsName("Dead"))
            {
                fsm.GetNavMeshAgent().agent.isStopped = false;
                fsm.GetAnim().SetBool("CanAttackPlayer", true);
                fsm.gameObject.transform.Find("Cube").GetComponent<Animator>().SetTrigger("Hit");
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
