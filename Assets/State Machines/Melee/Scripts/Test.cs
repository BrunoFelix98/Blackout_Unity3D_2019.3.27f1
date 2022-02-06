using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : StateMachineBehaviour
{
    private FiniteStateMachine fsm;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        fsm = animator.GetComponentInParent<FiniteStateMachine>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (fsm.currentState.name.Equals("Attack State"))
        {
            animator.SetBool("MeleeEnemyAttackState", true);
        }
        else
        {
            animator.SetBool("MeleeEnemyAttackState", false);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
