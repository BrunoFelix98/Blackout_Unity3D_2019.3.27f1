using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifetime : MonoBehaviour
{
    private float shootTimer = 0;
    public float shootTimeInterval = 5;
    public float damage;

    // Update is called once per frame
    void Update()
    {
        shootTimer += Time.deltaTime;

        if (shootTimer >= shootTimeInterval)
        {
            Destroy(gameObject);
            shootTimer = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().TakeDamage(damage);
            Destroy(gameObject);
        }
        else if (other.CompareTag("BossEnemy"))
        {
            other.GetComponent<BossEnemy>().TakeDamage(damage);
            Destroy(gameObject);
        }
        else if (other.CompareTag("InvisibleWalls") || other.CompareTag("Waypoints") || other.CompareTag("RangedEnemyGun") || other.CompareTag("PlayerWeapon") || other.CompareTag("Checkpoints") || other.CompareTag("BossBeam") || other.CompareTag("MeleeWeapon"))
        {
            return;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
