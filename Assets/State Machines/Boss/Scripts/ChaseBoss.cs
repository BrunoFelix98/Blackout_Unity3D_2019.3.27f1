using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Actions/ChaseBoss")]
public class ChaseBoss : Ai
{
    public override void Act(FiniteStateMachine fsm)
    {
        fsm.bGoingSomewhere = false;
        fsm.bStage2 = false;
        fsm.cState = ChaseState.ChaseStateBoss;
        fsm.GetBossEnemy().GetComponent<Animator>().SetBool("BossCanSee", true);
        fsm.GetBossEnemy().GetComponent<Animator>().SetBool("BossCanAttack", false);
        fsm.GetNavMeshAgent().GoToTarget();
    }
}
