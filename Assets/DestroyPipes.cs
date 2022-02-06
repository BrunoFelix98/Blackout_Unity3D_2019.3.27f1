using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPipes : MonoBehaviour
{
    [SerializeField]
    private float health = 100;
    public bool PipesDestroyed;

    private BossEnemy bossEnemy;

    // Start is called before the first frame update
    void Start()
    {
        PipesDestroyed = false;
        bossEnemy = GameObject.FindGameObjectWithTag("BossEnemy").GetComponent<BossEnemy>();
    }

    // Update is called once per frame
    void Update()
    {
        if(health == 75)
        {
            gameObject.GetComponent<MeshRenderer>().materials[0].color = Color.green;

        }
        if (health == 50)
        {
            gameObject.GetComponent<MeshRenderer>().materials[0].color = Color.yellow;

        }
        if (health == 25)
        {
            gameObject.GetComponent<MeshRenderer>().materials[0].color = Color.red;

        }
        if (health <= 0)
        {
            destroyPilars();
        }
    }
    public void TakeDamage(float amount)
    {
        health -= amount;
    }
    void destroyPilars()
    {
        bossEnemy.TakeHp = 0;
        PipesDestroyed = true;
        Destroy(gameObject);
    }
}
