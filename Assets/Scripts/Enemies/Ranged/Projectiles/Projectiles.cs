using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    public float speed;
    public float damage;
    public ShieldAbility shield;

    private Transform player;
    private Vector3 target;
    private GameObject knife;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        shield = GameObject.FindGameObjectWithTag("Player").GetComponent<ShieldAbility>();

        target = new Vector3(player.position.x, player.position.y, player.position.z);

        knife = GameObject.FindGameObjectWithTag("knife");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        transform.LookAt(target);

        if(transform.position.x == target.x && transform.position.y == target.y && transform.position.z == target.z)
        {
            destroyProjectile();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!shield.shieldActive)
            {
                FindObjectOfType<PlayerStats>().TakeDamage(damage);
            }
            destroyProjectile();
        }

        if (other.CompareTag("Walls") || other.CompareTag("Ground") || other.CompareTag("Pipes"))
        {
            destroyProjectile();
        }
    }
    void destroyProjectile()
    {
        Destroy(gameObject);
    }
}
