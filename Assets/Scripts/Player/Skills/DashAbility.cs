using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashAbility : Ability
{
    public PlayerStats stats;

    [SerializeField] private float dashForce;
    [SerializeField] private float dashDuration;
    private Animator anim;

    private Rigidbody player;

    public bool dashBool;
    public bool dUnlocked;
    private void Awake()
    {
        dashBool = false;
        dUnlocked = true;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && stats.stamina >= 50 && dashBool)
        {
            anim.SetBool("IsDashing", true);
            StartCoroutine(Cast());
        }
    }

    public override IEnumerator Cast()
    {
        player.AddForce(player.transform.forward * dashForce, ForceMode.VelocityChange);
        stats.stamina -= 50;
        
        anim.SetBool("IsWalking", false);

        yield return new WaitForSeconds(dashDuration);

        anim.SetBool("IsDashing", false);
        player.velocity = Vector3.zero;
    }

    public bool Unlocked()
    {
        return dUnlocked;
    }
}
