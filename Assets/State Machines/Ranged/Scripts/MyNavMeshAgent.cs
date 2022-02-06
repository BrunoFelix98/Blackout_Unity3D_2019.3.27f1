using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MyNavMeshAgent : MonoBehaviour
{
    // Start is called before the first frame update
    public NavMeshAgent agent;
    [SerializeField]
    public Transform Target;
    public Transform[] PatrolRotes;
    public List<Transform> Friends;
    private float TempDist;
    private float tempHealth;
    private float Dist;
    public Vector3 ClosestFriend;
    public bool FindingBuddy;
    public FiniteStateMachine Friend;

    public Vector3 targetOldPosition = Vector3.zero;

    [SerializeField]
    public float checkEvery = 1; // check every one second
    public float time;



    private int currWaypoint;

    public Transform GetTarget()
    {
        return Target;
    }
    public NavMeshAgent GetAgent()
    {
        return agent;
    }
    public void StopAgent()
    {
        agent.isStopped = !agent.isStopped;
      
       // agent.ResetPath();
    }
    public void GoToTarget()
    {
        if (Target.hasChanged == true)
        {
            agent.SetDestination(Target.position);
            Target.hasChanged = false;
        }
    }
    public void GoToNextWaypoint()
    {
        if (!GetComponent<FiniteStateMachine>().Boss)
        {
            agent.SetDestination(PatrolRotes[currWaypoint].position);
        }

        currWaypoint++;

        if (currWaypoint >= PatrolRotes.Length)
        {
            currWaypoint = 0;
        }
    }
    public bool IsAtDestination()
    {
        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                {
                    return true;
                }
            }
        }
        return false;
    }

    void Start()
    {
        currWaypoint = 0;
        FindingBuddy = false;
        agent = GetComponent<NavMeshAgent>();

        GoToNextWaypoint();
    }
   public Vector3 FindBuddy()
   {
        if (Friends.Count != 0)
        {
            ClosestFriend = Friends[0].position;

            for (int i = 0; i < Friends.Count; i++)
            {
                Dist = Vector3.Distance(ClosestFriend, transform.position);

                TempDist = Vector3.Distance(Friends[i].position, transform.position);

                if (TempDist <= Dist)
                {
                    if (Friends[i].GetComponent<Enemy>().health >= 50)
                    {
                        ClosestFriend = Friends[i].position;
                        Friend = Friends[i].GetComponent<FiniteStateMachine>();
                    }
                    else
                    {
                        tempHealth = Friends[i].GetComponent<Enemy>().health;

                        if (tempHealth >= GetComponent<Enemy>().health)
                        {
                            ClosestFriend = Friends[i].position;
                            Friend = Friends[i].GetComponent<FiniteStateMachine>();
                        }
                        else
                        {
                            ClosestFriend = Friends[0].position;
                            Friend = Friends[0].GetComponent<FiniteStateMachine>();
                        }
                    }
                }
            }
            FindingBuddy = true;
            agent.SetDestination(ClosestFriend);
        }
        return ClosestFriend;
    }

    void Update()
    {
        for (int i = 0; i < Friends.Count; i++)
        {
            if (Friends[i] == null)
            {
                Friends.RemoveAt(i);
            }
        }
    }

    /*public void OnDrawGizmos()
    {
        float totalFOV = 60.0f;
        float rayRange = 25.0f;
        float halfFOV = totalFOV / 2.0f;

        Quaternion leftRayRotation = Quaternion.AngleAxis(-halfFOV, Vector3.up);
        Quaternion rightRayRotation = Quaternion.AngleAxis(halfFOV, Vector3.up);
        Vector3 leftRayDirection = leftRayRotation * transform.forward;
        Vector3 rightRayDirection = rightRayRotation * transform.forward;

        Gizmos.DrawRay(transform.position, leftRayDirection * rayRange);
        Gizmos.DrawRay(transform.position, rightRayDirection * rayRange);
        Gizmos.DrawWireSphere(transform.position, rayRange);
    }*/
}
