using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Actions/AttackBoss2")]
public class BossAttack2 : Ai
{
    public GameObject shootPrefab;
    public GameObject beamPrefab;
    public GameObject melee;
    public float shooTimeInterval = 2;
    private float shootTimer = 0;
    public const float damagePerTick = 25;
    public const float tickPeriod = 1;
    private float lastTickTime = tickPeriod;
    private BeamHits beamObject;

    public override void Act(FiniteStateMachine fsm)
    {
        if (fsm.Boss)
        {
            Debug.Log(fsm.canBeam + "BEAM BEAM");
        }

        beamPrefab = fsm.GetComponent<BossEnemy>().beamPrefab;

        if (fsm.Ranged)
        {
            shootTimer += Time.deltaTime;
            if (shootTimer >= shooTimeInterval) 
            {
                shootTimer = 0;
                GameObject bullet = Instantiate(shootPrefab, fsm.transform.position + fsm.transform.forward, Quaternion.identity);
            }
        }

        if (fsm.canBeam)
        {
            //beamPrefab.GetComponent<BeamHits>().laser.SetActive(true);
            lastTickTime += Time.deltaTime;

            fsm.GetComponent<Animator>().SetBool("CanBeam", true);

            RaycastHit hit;

            Physics.Raycast(GameObject.FindGameObjectWithTag("Boss").transform.position, fsm.GetNavMeshAgent().GetTarget().transform.position - GameObject.FindGameObjectWithTag("Boss").transform.position, out hit, Mathf.Infinity);

            if (hit.collider != null && lastTickTime >= tickPeriod)
            {
                lastTickTime = 0;

                Vector3 BeamTarget = fsm.GetComponentInChildren<BeamHits>().laser.GetComponent<LineRenderer>().transform.InverseTransformPoint(hit.point);

                if (hit.collider.CompareTag("Player"))
                {
                    beamPrefab.GetComponent<BeamHits>().SetLaserTarget(BeamTarget);
                    if (!hit.collider.gameObject.GetComponent<ShieldAbility>().shieldActive)
                    {
                        hit.collider.gameObject.GetComponent<PlayerStats>().TakeDamage(damagePerTick);
                    }
                }
                else if (hit.collider.CompareTag("Pipes"))
                {
                    beamPrefab.GetComponent<BeamHits>().SetLaserTarget(BeamTarget);
                    hit.collider.gameObject.GetComponent<DestroyPipes>().TakeDamage(damagePerTick);
                }
            }

            if (lastTickTime >= tickPeriod)
            {
                fsm.GetComponent<Animator>().SetBool("CanBeam", false);
            }
            fsm.transform.LookAt(fsm.GetBossEnemy().player);
        }
    }
}
