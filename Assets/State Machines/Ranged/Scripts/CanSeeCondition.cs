using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Finite State Machine/Condition/Can See")]
public class CanSeeCondition : Condition
{
    [SerializeField]
    private bool Negation;
    [SerializeField]
    private float ViewAngle;
    [SerializeField]
    private float ViewDistance;

    public override bool test(FiniteStateMachine fsm)
    {
        float distanceToFriend = Vector3.Distance(fsm.GetNavMeshAgent().ClosestFriend, fsm.GetNavMeshAgent().GetAgent().transform.position);

        float halfFOV = ViewAngle / 2.0f;

        Quaternion leftRayRotation = Quaternion.AngleAxis(-halfFOV, Vector3.up);
        Quaternion rightRayRotation = Quaternion.AngleAxis(halfFOV, Vector3.up);
        Vector3 leftRayDirection = leftRayRotation * fsm.transform.forward;
        Vector3 rightRayDirection = rightRayRotation * fsm.transform.forward;

        Transform target = fsm.GetNavMeshAgent().GetTarget();
        float distance = Vector3.Distance(target.position, fsm.transform.position);
        Vector3 targetDir = Vector3.Normalize(target.position - fsm.transform.position);
        float leftAngle = Vector3.Angle(leftRayDirection, fsm.transform.forward);
        float rightAngle = Vector3.Angle(rightRayDirection, fsm.transform.forward);

        if (((-30 <= leftAngle) || (30 >= -rightAngle)) && (distance < ViewDistance))
        {
            if (!fsm.Boss)
            {
                fsm.GetAnim().SetBool("CanSeePlayer", true);
                return !Negation;
            }
            
            return !Negation;
        }
        else
        {
            if (!fsm.Boss)
            {
                fsm.GetAnim().SetBool("CanAttackPlayer", false);
                fsm.GetAnim().SetBool("CanSeePlayer", false);
                return Negation;
            }
            return Negation;
        }
    }
}