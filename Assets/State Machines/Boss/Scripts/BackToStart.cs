using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Actions/BackToStart")]
public class BackToStart : Ai
{
    [SerializeField]
    private Vector3 initialPos;

    public override void Act(FiniteStateMachine fsm)
    {
        fsm.GetBossEnemy().GetComponent<Animator>().SetBool("BossCanSee", false);

        if (fsm.bStage2 == false)
        {
            if (fsm.bGoingSomewhere == false)
            {
                fsm.GetNavMeshAgent().GetAgent().SetDestination(initialPos);
                fsm.bGoingSomewhere = true;
            }

            if (Vector3.Distance(fsm.GetBossEnemy().transform.position, initialPos) <= 2)
            {

                fsm.GetBossEnemy().health = fsm.GetBossEnemy().maxHealth;
            }
        }
    }
}
