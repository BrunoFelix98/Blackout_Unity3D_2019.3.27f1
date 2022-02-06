using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MeleeAbility : MonoBehaviour
{
    [SerializeField] public float damage;

    private Transform enemy;
    private Vector3 target;

    private float speed;

    public bool meleeBool;

    // Start is called before the first frame update
    void Start()
    {
        meleeBool = false;

        if (!SceneManager.GetActiveScene().name.Equals("BossFightStage2"))
        {
            enemy = GameObject.FindGameObjectWithTag("Enemy").transform;

            target = new Vector3(enemy.position.x, enemy.position.y, enemy.position.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && meleeBool)
        {
            gameObject.transform.Find("Cube").GetComponent<Animator>().SetTrigger("Hit");
            GetComponent<Animator>().SetBool("MeleeActive", true);
        }

        if (Input.GetMouseButtonUp(0) && meleeBool)
        {
            GetComponent<Animator>().SetBool("MeleeActive", false);
        }

        if (!meleeBool)
        {
            GetComponent<Animator>().SetBool("MeleeActive", false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") && meleeBool)
        {
            other.GetComponent<Enemy>().TakeDamage(damage);
        }
    }
}
