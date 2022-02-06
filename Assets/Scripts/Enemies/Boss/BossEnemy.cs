using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using UnityEngine.UI;

public class BossEnemy : MonoBehaviour
{
    //getting the player transform
    public Transform player;

    //Health
    public float health;
    public float maxHealth;
    public float healthOverTime;
    public Slider healthBar;
    public float TakeHp = 0;
    public float TakeHpInterval = 10;
    public float wait;

    public bool canDamage;

    //gets a list of pipes
    public List<GameObject> Pipes;

    public GameObject beamPrefab;

    //private GameObject[] DestroyPipes;
    private  DestroyPipes DestroyPipes;

    private Animator anim;

    public float bossRange;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        healthBar.maxValue = health;

        UpdateUI();
        healthBar.gameObject.SetActive(false);
        bossRange = 30;
        DestroyPipes = GetComponent<DestroyPipes>();

        anim = GetComponent<Animator>();
    }
    public void Update()
    {
        CalculateValues();

        wait += Time.deltaTime;

        TakeHp += Time.deltaTime;

        if (wait > anim.GetCurrentAnimatorStateInfo(0).length)
        {
            anim.SetBool("WasHit", false);
            wait = 0;
        }
    }
    private void CalculateValues()
    {
        // health += healthOverTime * Time.deltaTime / 2;

        if (health <= 1)
        {
            Destroy();
        }

        /*Vector3 rotation = healthBar.transform.rotation.eulerAngles;
        rotation.x = 0;
        healthBar.transform.rotation = Quaternion.Euler(rotation);*/

        if (!healthBar.gameObject.activeSelf)
        {
            ShowHealth();
        }

        UpdateUI();
    }

    private void UpdateUI()
    {
        health = Mathf.Clamp(health, 0, maxHealth);

        healthBar.value = health;

        for (int i = 0; i < Pipes.Count; i++)
        {
            if (Pipes[i] == null)
            {
                Debug.Log("Pipe " + i + " Is nonexistent");
                if (canDamage)
                {
                    TakeHp += Time.deltaTime;
                }
            }
        }
    }

    public void TakeDamage(float amount)
    {
        if (!GetComponent<FiniteStateMachine>().bStage2)
        {
            canDamage = true;
            health -= amount;
            anim.SetBool("WasHit", true);
            UpdateUI();

            Debug.Log("Stage 1");
        }

        if(GetComponent<FiniteStateMachine>().bStage2)
        {
            Debug.Log("Stage 2");

            canDamage = false;

            if (TakeHp >= TakeHpInterval)
            {
                canDamage = false;
            }
            else
            {
                canDamage = true;
            }

            if(canDamage)
            {
                health -= amount;
                anim.SetBool("WasHit", true);
                UpdateUI();
            }
        }
    }

    //Replace death with boss dying cutscene
    public void Destroy()
    {
        GameObject.FindGameObjectWithTag("EndGame").GetComponent<VideoScene>().enabled = true;
        GameObject.FindGameObjectWithTag("EndGame").GetComponent<VideoPlayer>().enabled = true;
        GameObject.FindGameObjectWithTag("EndGame").GetComponent<VideoScene>().PlayVideo();
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>().invincible = true;
        Destroy(healthBar.gameObject);
        Destroy(gameObject);
        if (GameObject.FindGameObjectWithTag("EndGame").GetComponent<VideoScene>().isDone)
        {
            SceneManager.LoadScene("Credits");
        }

    }

    public void ShowHealth()
    {
        RaycastHit hit;

        if (Vector3.Distance(transform.position, player.position) < bossRange)
        {
            if (Physics.Raycast(transform.position, (player.position - transform.position), out hit, 30))
            {
                if (hit.collider.CompareTag("Player"))
                {
                    healthBar.gameObject.SetActive(true);
                }
            }
        }
    }

    public void Stage()
    {
        if (Pipes == null)
        {
            Destroy();
        }
    }
}
