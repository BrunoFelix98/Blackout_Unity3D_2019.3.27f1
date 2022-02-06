using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    //getting the player transform
    public Transform player;

    //Health
    public float health;
    public float maxHealth;
    public float healthOverTime;
    public Slider healthBar;

    public float animTimer;

    public bool shotE;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        healthBar.maxValue = health;

        //shotE = false;

        UpdateUI();
    }
    public void Update()
    {
        animTimer += Time.deltaTime;
        CalculateValues();

        if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            gameObject.transform.Find("Cube").gameObject.SetActive(true);
        }
        else
        {
            gameObject.transform.Find("Cube").gameObject.SetActive(false);
        }
    }
    private void CalculateValues()
    {
       // health += healthOverTime * Time.deltaTime / 2;

        if (health <= 1)
        {
            print("Enemy dead");
            GetComponent<Animator>().SetTrigger("HealthZero");

            if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Dead"))
            {
                GetComponent<MyNavMeshAgent>().StopAgent();
                Destroy();
            }
        }

        healthBar.transform.LookAt(Camera.main.transform);
        /*Vector3 rotation = healthBar.transform.rotation.eulerAngles;
        rotation.x = 0;
        healthBar.transform.rotation = Quaternion.Euler(rotation);*/

        ShowHealth();
        UpdateUI();
    }

    private void UpdateUI()
    {
        health = Mathf.Clamp(health, 0, maxHealth);

        healthBar.value = health;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        UpdateUI();

        shotE = true;

        GetComponent<Animator>().SetTrigger("TookDamage");
        //GetComponent<FiniteStateMachine>().GetNavMeshAgent().GoToTarget();
    }

    public void Destroy()
    {
        GetComponent<MyNavMeshAgent>().Friends.Remove(gameObject.transform);
        Destroy(healthBar.gameObject);
        Destroy(gameObject, GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
    }

    public void ShowHealth()
    {
        float distanceToEnemy = Vector3.Distance(transform.position, player.transform.position);
        if (distanceToEnemy < 50)
        {
            healthBar.gameObject.SetActive(true);
        }
        else
        {
            healthBar.gameObject.SetActive(false);
        }      
    }
}