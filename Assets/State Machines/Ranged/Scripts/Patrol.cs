using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Finite State Machine/Actions/Patrol")]
public class Patrol : Ai
{
    public override void Act(FiniteStateMachine fsm)
    {
        fsm.wait += Time.deltaTime;
        if (fsm.Ranged)
        {
            fsm.GetAnim().SetBool("IsInRange", false);
        }
        //change the stopping distance to 1 

        //Debug.Log("1 " + fsm.name + " " + fsm.GetNavMeshAgent().IsAtDestination());

        if (!fsm.GetNavMeshAgent().IsAtDestination())
        {
            //Debug.Log("2 " + fsm.name + " " + fsm.GetNavMeshAgent().GetAgent().hasPath);

            fsm.GetAnim().SetBool("IsAtDestination", false);
            if(fsm.Ranged && fsm.GetAnim().GetCurrentAnimatorStateInfo(0).IsName("Walking"))
            {
                fsm.GetNavMeshAgent().agent.isStopped = false;
            }

            //if (!fsm.GetNavMeshAgent().GetAgent().hasPath)
            //{
            //Debug.Log("3 " + fsm.name + " ");
            //Debug.Log("4 " + fsm.name + " " + fsm.GetAnim().GetCurrentAnimatorStateInfo(0).IsName("Walking"));
            //}
        }
        else
        {
            if (fsm.GetAnim().GetBool("TookDamage") == true)
            {
                fsm.GetAnim().SetBool("IsAtDestination", false);
            }

            //Debug.Log("I m at a destination");

            if (fsm.GetAnim().GetBool("IsAtDestination") == false)
            {
                //Debug.Log("Turning bool to true");

                fsm.GetAnim().SetBool("IsAtDestination", true);

                fsm.wait = 0;
                
            }

            //Debug.Log("5 " + fsm.name + " " + fsm.GetAnim().GetCurrentAnimatorStateInfo(0).IsName("Walking"));
            //Debug.Log("6 " + fsm.name + " " + fsm.GetAnim().GetCurrentAnimatorStateInfo(0).IsName("Idle"));

            if (fsm.wait > fsm.GetAnim().GetCurrentAnimatorStateInfo(0).length)
            {
                //Debug.Log("Walking" + " " + fsm.name);
                fsm.GetNavMeshAgent().GoToNextWaypoint();
                fsm.GetAnim().SetBool("IsAtDestination", false);
                fsm.wait = 0;
            } 
        }
    }

    bool AnimatorIsPlayingTime(FiniteStateMachine fsm)
    {
        return fsm.GetAnim().GetCurrentAnimatorStateInfo(0).normalizedTime < 1f;
    }

    bool AnimatorIsPlaying(string stateName, FiniteStateMachine fsm)
    {
        return AnimatorIsPlayingTime(fsm) && fsm.GetAnim().GetCurrentAnimatorStateInfo(0).IsName(stateName);
    }

    void NewMethod(FiniteStateMachine fsm)
    {
        fsm.GetAnim().SetBool("IsAtDestination", false);
    }

}