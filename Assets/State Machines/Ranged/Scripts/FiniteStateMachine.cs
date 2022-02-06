using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public enum ChaseState
{ 
    ChaseState,
    ChaseStateMelee,
    ChaseStateBoss
}

public class FiniteStateMachine : MonoBehaviour
{
    private MyNavMeshAgent navMeshAgent;
    private Enemy enemy;
    private BossEnemy bEnemy;
    private Animator anim;
    public State initialState;
    public State currentState;


    public ChaseState cState;

    public bool Ranged;
    public bool Boss;
    public bool bGoingSomewhere;
    public bool canBeam;
    public bool bStage2;

    public float beamTimer;
    public float wait;

    void Start()
    {
        currentState = initialState;
        navMeshAgent = GetComponent<MyNavMeshAgent>();
        enemy = GetComponent<Enemy>();
        bEnemy = GetComponent<BossEnemy>();
        anim = GetComponent<Animator>();
        bGoingSomewhere = false;
        canBeam = false;
        bStage2 = false;
    }
    void Update()
    {
        Transition triggerTransition = null;
        foreach (Transition t in currentState.GetTransition())
        {
            if (t.isTriggerd(this))
            {
                triggerTransition = t;
                break;
            }
        }
        List<Ai> actions = new List<Ai>();
        if (triggerTransition)
        {
            State targetState = triggerTransition.GetTargetState();
            actions.Add(currentState.GetExitAction());
            actions.Add(triggerTransition.getAction());
            actions.Add(targetState.GetEntryAction());
            currentState = targetState;

        }
        else
        {
            foreach (Ai a in currentState.GetActions())
            {
                actions.Add(a);
            }
        }

        if (Boss)
        {
            beamTimer += Time.deltaTime;

            if (beamTimer >= 15)
            {
                beamTimer -= 15;
            }

            canBeam = beamTimer > 10;
        }

        DoActions(actions);
    }
    public void DoActions(List<Ai> actions)
    {
        foreach (Ai a in actions)
        {
            if (a != null)
            {
                a.Act(this);

            }
        }
    }
    public MyNavMeshAgent GetNavMeshAgent()
    {
        return navMeshAgent;
    }
    public Enemy GetEnemy()
    {
        return enemy;
    }
    public Animator GetAnim()
    {
        return anim;
    }
    public BossEnemy GetBossEnemy()
    {
        return bEnemy;
    }

}
