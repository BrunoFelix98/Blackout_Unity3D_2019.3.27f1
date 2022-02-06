using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Condition/ChaseWBuddy")]
public class ChaseWBuddy : Condition
{
    [SerializeField]
    private bool Negation;
    public override bool test(FiniteStateMachine fsm)
    {
        float distance = Vector3.Distance(fsm.GetNavMeshAgent().ClosestFriend, fsm.GetNavMeshAgent().GetAgent().transform.position);

        if (fsm.GetNavMeshAgent().ClosestFriend != null && distance <= 10 && fsm.GetNavMeshAgent().FindingBuddy)
        {
            if (!fsm.GetAnim().GetCurrentAnimatorStateInfo(0).IsName("GettingHit"))
            {
                if (!fsm.GetAnim().GetCurrentAnimatorStateInfo(0).IsName("Dead"))
                {
                    fsm.GetNavMeshAgent().Friend.GetNavMeshAgent().GoToTarget();
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
            fsm.GetComponent<Animator>().SetBool("HasBuddy", true);
            //This means that the agent has already reached his friend.
            return !Negation;
        }
        else
        {
            //This means that the agent hasnt reached his friend.
            return Negation;
        }
    }
}