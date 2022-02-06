using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldAbility : MonoBehaviour
{
    public GameObject shieldPrefab;
    private GameObject shield;
    public PlayerStats stats;
    private Rigidbody player;

    public bool shieldBool;
    public bool shieldActive;

    private Animator anim;

    void Awake()
    {
        shieldBool = false;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();

        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool mouseButton = Input.GetMouseButton(0);

        if (mouseButton && stats.stamina >= 1 && shieldBool && !shieldActive)
        {
            shieldActive = true;
            shield = Instantiate(shieldPrefab, player.transform.position + new Vector3(0, 1, 0), Quaternion.LookRotation(this.transform.forward, Vector3.up));
            anim.SetBool("ShieldActive", true);
        }

        if ((!mouseButton || stats.stamina < 1) && shieldBool)
        {
            destroyShield();
        }

        if (shield)
        {
            stats.stamina -= 20 * Time.deltaTime;
            shield.transform.position = player.transform.position + new Vector3(0, 1, 0);
        }
    }

    public void destroyShield()
    {
        anim.SetBool("ShieldActive", false);
        shieldActive = false;
        Destroy(shield);
    }
}
