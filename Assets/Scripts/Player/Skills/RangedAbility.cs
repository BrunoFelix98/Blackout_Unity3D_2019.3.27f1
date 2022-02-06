using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAbility : Ability
{
    public GameObject lightingPrefab;
    public GameObject firePoint;
    private GameObject SpawnedLighting;
    private Vector3 shootingPos;
    public PlayerStats stats;
    [SerializeField] private float speed;
    [SerializeField] private float shootTimer;
    [SerializeField] private float shootTimeInterval;

    private Animator anim;

    public bool rangedBool;
    public bool rUnlocked;

    public void Awake()
    {
        rangedBool = false;
        rUnlocked = false;

        anim = GetComponent<Animator>();
    }

    void Update()
    {
        shootTimer += Time.deltaTime;

        shootingPos = firePoint.transform.position;

        if (Input.GetMouseButtonDown(0) && stats.stamina >= 5 && Time.timeScale == 1.0f && rangedBool)
        {
            if (shootTimer >= shootTimeInterval)
            {
                anim.SetBool("RangedActive", true);
                StartCoroutine(Cast());
            }
            
        }
        else
        {
            anim.SetBool("RangedActive", false);
        }

    }

    public override IEnumerator Cast()
    {
        SpawnedLighting = Instantiate(lightingPrefab, new Vector3(shootingPos.x, shootingPos.y, shootingPos.z), Quaternion.LookRotation(this.transform.forward, Vector3.up));
        SpawnedLighting.GetComponent<Rigidbody>().velocity = Vector3.Normalize(firePoint.transform.forward) * speed;

        anim.SetBool("IsWalking", false);

        stats.stamina -= 5;
        shootTimer = 0;

        yield return null; //new WaitForSeconds(shootTimeInterval);
    }

    public bool Unlocked()
    {
        return rUnlocked;
    }
}