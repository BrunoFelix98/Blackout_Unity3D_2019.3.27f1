using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Finite State Machine/Condition/Find Buddy Condition")]
public class FindBuddyCondition : Condition
{
    [SerializeField]
    private bool Negation;
    public override bool test(FiniteStateMachine fsm)
    {
        if (fsm.GetEnemy().health <= 50 && fsm.GetNavMeshAgent().FindingBuddy == false)
        {
            fsm.GetComponent<Animator>().SetTrigger("HalfHealth");
            return !Negation;
        }
        else
        {
            return Negation;
        }
    }
}
