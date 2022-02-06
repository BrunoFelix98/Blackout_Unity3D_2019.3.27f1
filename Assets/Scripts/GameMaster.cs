using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    private static GameMaster instance;
    public Vector3 LastCheckpointPos;
    public bool[] unlockedAbility;
    public bool active;
    private void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        //Cheats
        if(Input.GetKey("h"))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>().health = 100;
        }

        if (Input.GetKey("j"))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>().stamina = 100;
        }

        if (Input.GetKey("u"))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>().health = 0;
        }

        if (Input.GetKey("y"))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<RangedAbility>().lightingPrefab.GetComponent<Lifetime>().damage = 50;
        }
    }
}
