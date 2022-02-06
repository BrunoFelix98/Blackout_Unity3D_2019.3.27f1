using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserColliders : MonoBehaviour
{
    public GameObject player;
    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
}
