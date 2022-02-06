using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class GiveAbilities : MonoBehaviour
{
    private GameObject character;
    private GameObject Tattoo;
    private GameObject sprites;
    private bool CanGive;
    // Start is called before the first frame update
    void Start()
    {
        sprites = GameObject.FindGameObjectWithTag("Btns");
        character = GameObject.FindGameObjectWithTag("Player");
        Tattoo = GameObject.FindGameObjectWithTag("Tattoo");
        sprites.SetActive(false);
        CanGive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (CanGive)
        {
            if (Input.GetKey(KeyCode.E))
            {
                Debug.Log("i pressed E");
                character.GetComponent<CharacterControler3D>().TattooGiver = true;
                Tattoo.GetComponent<SkinnedMeshRenderer>().enabled = true;
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>().invincible = true;
                GameObject.FindGameObjectWithTag("GiveTattoo").GetComponent<VideoController>().enabled = true;
                GameObject.FindGameObjectWithTag("GiveTattoo").GetComponent<VideoPlayer>().enabled = true;

                GameObject.FindGameObjectWithTag("GiveTattoo").GetComponent<VideoController>().PlayVideo();
                Tattoo.SetActive(true);
            }
        }  
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            sprites.SetActive(true);
            Debug.Log("player");
            CanGive = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        sprites.SetActive(false);
        CanGive = false;
    }
}
