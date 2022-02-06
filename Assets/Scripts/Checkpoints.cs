using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Checkpoints : MonoBehaviour
{
    private GameMaster gn;

    public TextMeshProUGUI checkpointText;

   void Start()
    {
        gn = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        checkpointText.gameObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            checkpointText.gameObject.SetActive(true);
            gn.LastCheckpointPos = transform.position;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        checkpointText.gameObject.SetActive(false);
    }
}