using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Actions/Stage2Boss")]
public class Stage2 : Ai
{
    [SerializeField]
    private Vector3 bossRoomBoss;
    [SerializeField]
    private Vector3 bossRoomPlayer;
    public override void Act(FiniteStateMachine fsm)
    {
        fsm.bStage2 = true;
        fsm.canBeam = true;
        fsm.GetBossEnemy().GetComponent<Animator>().SetTrigger("Health");
        fsm.GetBossEnemy().GetComponent<BossEnemy>().bossRange = 100;
        fsm.GetBossEnemy().GetComponent<MyNavMeshAgent>().GetAgent().Warp(bossRoomBoss);
        fsm.GetBossEnemy().transform.position = bossRoomBoss;
        fsm.GetBossEnemy().GetComponent<BossEnemy>().player.transform.position = bossRoomPlayer;
    }
}