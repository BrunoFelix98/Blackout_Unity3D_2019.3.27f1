using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Actions/AttackBoss")]
public class BossAttack : Ai
{
    public GameObject shootPrefab;
    public GameObject Boss;
    public float shooTimeInterval = 2;
    private float shootTimer = 0;
    public override void Act(FiniteStateMachine fsm)
    {
        fsm.GetBossEnemy().GetComponent<Animator>().SetBool("BossCanAttack", true);

        if (fsm.Ranged)
        {
            if (!fsm.GetAnim().GetCurrentAnimatorStateInfo(0).IsName("IsHit"))
            {
                shootTimer += Time.deltaTime;

                if (shootTimer >= shooTimeInterval)
                {
                    shootTimer = 0;
                    GameObject bullet = Instantiate(shootPrefab, fsm.transform.position + fsm.transform.forward, Quaternion.identity);

                    fsm.GetNavMeshAgent().transform.LookAt(fsm.GetNavMeshAgent().GetTarget());
                }
            }
            else
            {
                fsm.GetNavMeshAgent().agent.isStopped = true;

            }
        }
    }
}