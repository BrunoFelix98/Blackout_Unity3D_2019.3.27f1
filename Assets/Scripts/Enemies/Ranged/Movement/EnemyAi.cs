using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
     
    private Vector3 StartingPos;
    private Vector3 roamPosition;
    private void Start()
    {
        StartingPos = transform.position;
        roamPosition = Getrandomdir();
    }
    private Vector3 RoamingDir()
    {
      return StartingPos + Getrandomdir() * Random.Range(10f, 70f);
    }
    public static Vector3 Getrandomdir()
    {
        return new Vector3(UnityEngine.Random.Range(-1f , 1f ), UnityEngine.Random.Range(-1f, 1f)).normalized;
    }
}
