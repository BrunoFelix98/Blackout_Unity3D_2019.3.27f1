using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Actions/Attack Ranged")]
public class Attack : Ai
{
    public GameObject shootPrefab;
    public float shootTimeInterval = 2;
    private float shootTimer = 0 ;
    public override void Act(FiniteStateMachine fsm)
    {
        fsm.GetAnim().SetBool("CanAttackPlayer", true);
        fsm.GetAnim().SetBool("IsInRange", true);
        if (!fsm.GetAnim().GetCurrentAnimatorStateInfo(0).IsName("PreparingAttack"))
        {
            if (!fsm.GetAnim().GetCurrentAnimatorStateInfo(0).IsName("GettingHit"))
            {
                if (!fsm.GetAnim().GetCurrentAnimatorStateInfo(0).IsName("Dead"))
                {
                    shootTimer += Time.deltaTime;

                    if (shootTimer >= shootTimeInterval)
                    {
                        GameObject bullet = Instantiate(shootPrefab, fsm.transform.position + fsm.transform.forward, Quaternion.identity);
                        fsm.GetNavMeshAgent().transform.LookAt(fsm.GetNavMeshAgent().GetTarget());
                        shootTimer = 0;
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
        }
        else
        {
            fsm.GetNavMeshAgent().agent.isStopped = true;
        }
    }
}
