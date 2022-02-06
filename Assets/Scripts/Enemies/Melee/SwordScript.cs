using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour
{
    public float damage;

    public ShieldAbility player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<ShieldAbility>();
    }
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!player.shieldActive)
            {
                FindObjectOfType<PlayerStats>().TakeDamage(damage);
            } 
            GetComponentInParent<Enemy>().shotE = false;
        }
    }
}
