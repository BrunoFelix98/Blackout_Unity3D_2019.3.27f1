using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    //Health
    public float health;
    public float healthOverTime;
    public float wait;
    public Slider healthBar;

    //Stamina
    public float stamina;
    public float staminaOverTime;
    public Slider staminaBar;
    private GameMaster gm;

    public bool invincible;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        healthBar.maxValue = health;
        staminaBar.maxValue = stamina;

        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();

        transform.position = gm.LastCheckpointPos;

        anim = GetComponent<Animator>();

        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        CalculateValues();
        Checkpoints();

        wait += Time.deltaTime;

        if (wait > anim.GetCurrentAnimatorStateInfo(0).length)
        {
            if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Die"))
            {
                anim.SetBool("GetHit", false);
                wait = 0;
            }
        }
    }

    private void CalculateValues()
    {
        stamina += staminaOverTime * Time.deltaTime;


        UpdateUI();
    }

    private void UpdateUI()
    {
        health = Mathf.Clamp(health, 0, 100f);
        stamina = Mathf.Clamp(stamina, 0, 100f);

        healthBar.value = health;
        staminaBar.value = stamina;
    }

    public void TakeDamage(float amount)
    {
        if (!invincible)
        {
            health -= amount;

            anim.SetBool("GetHit", true);

            UpdateUI();
        }
    }
    public void Checkpoints()
    {
        if (Input.GetKeyDown(KeyCode.T) || health <= 0)
        {
            anim.SetBool("Dead", true);

            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Die"))
            {
                if (wait > anim.GetCurrentAnimatorStateInfo(0).length)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
            }
        }
    }
}
