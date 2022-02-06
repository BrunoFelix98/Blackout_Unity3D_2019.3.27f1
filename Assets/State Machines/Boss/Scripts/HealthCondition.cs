using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

[CreateAssetMenu(menuName = "Finite State Machine/Condition/Health condition")]
public class HealthCondition : Condition
{
    [SerializeField]
    private bool Negation;

    public override bool test(FiniteStateMachine fsm)
    {
        if (fsm.GetBossEnemy().health <= fsm.GetBossEnemy().maxHealth / 2)
        {
            GameObject.FindGameObjectWithTag("BossRunningVid").GetComponent<VideoController>().enabled = true;
            GameObject.FindGameObjectWithTag("BossRunningVid").GetComponent<VideoPlayer>().enabled = true;
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>().invincible = true;

            GameObject.FindGameObjectWithTag("BossRunningVid").GetComponent<VideoController>().PlayVideo();
            return !Negation;
        }
        else
        {
            return Negation;
        }
    }
}