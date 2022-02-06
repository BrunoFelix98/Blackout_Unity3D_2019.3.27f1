using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skills : MonoBehaviour
{
    public GameObject bullet;

    public float speed;
    private Vector3 Trajectory;
    private void Start()
    {
        
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {



            GameObject ramgedattacl = Instantiate(bullet, this.gameObject.transform.position + this.gameObject.transform.forward, Quaternion.identity);
           // ramgedattacl.GetComponent<Rigidbody>().velocity = Vector3.Normalize() * 10;

        }
        if (Input.GetMouseButtonDown(2))
            Debug.Log("Pressed middle click.");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            destroyProjectile();
        }
    }
    void destroyProjectile()
    {
        Destroy(gameObject);
    }

}
