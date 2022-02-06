using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamHits : MonoBehaviour
{
    public GameObject laser;
    public ShieldAbility shield;

    // Start is called before the first frame update
    void Start()
    {
        shield = GameObject.FindGameObjectWithTag("Player").GetComponent<ShieldAbility>();
    }

    void Update()
    {
        if (!GetComponentInParent<FiniteStateMachine>().canBeam || !GetComponentInParent<FiniteStateMachine>().bStage2)
        {
            disableBeam();
        }
        else
        {
            laser.SetActive(true);
        }
    }

    public void disableBeam()
    {
        laser.SetActive(false);
    }

    public void SetLaserTarget(Vector3 target)
    {
        Debug.Log(target);
        laser.GetComponent<LineRenderer>().SetPosition(0, target);
        Debug.Log("BEAM ACTIVATE");
    }
}