using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class CharacterControler3D : MonoBehaviour
{
    public float speed;
    public float jumpForce = 2.0f;
    public Vector3 jump;
    public bool isGrounded;
    public bool TattooGiver;

    public float distanceToFeet;

    public PlayerStats stats;

    private GameMaster Gm;

    public Sprite rangedSprite;

    Rigidbody rb;

    private Animator anim;

    private AudioManager AM;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 3.0f, 0.0f);

        distanceToFeet = GetComponent<Collider>().bounds.extents.y;

        Gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        transform.position = Gm.LastCheckpointPos;
        TattooGiver = false;
        anim = GetComponent<Animator>();

        AM = FindObjectOfType<AudioManager>();

        AM.Play("GameBG");
        AM.Stop("MenuBG");
    }
    void Update()
    {
        PlayerMovement();

        if (TattooGiver)
        {
            GetComponent<Interactable>().options[3].unlocked = true;
            GetComponent<Interactable>().options[3].sprite = rangedSprite;
            GetComponent<Interactable>().options[3].color = Color.yellow;

            for (int i = 0; i < Gm.unlockedAbility.Length; i++)
            {
                Gm.unlockedAbility[i] = GetComponent<Interactable>().options[i].unlocked;
            }
        }
        OutOfWorld();
    }
    void PlayerMovement()
    {
        float Horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");
        Vector3 playerMov = new Vector3(Horizontal, 0f, Vertical) * speed * Time.deltaTime;
        transform.Translate(playerMov, Space.Self);

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            anim.SetBool("IsStoped", false);
            anim.SetBool("IsJumping", true);
        }
        else
        {
            anim.SetBool("IsJumping", false);
            anim.SetBool("IsStoped", true);
        }
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) && (anim.GetBool("IsDashing") == false || anim.GetBool("MeleeActive") == false || anim.GetBool("RangedActive") == false || anim.GetBool("ShieldActive") == false))
        {
            anim.SetBool("IsWalking", true);
            anim.SetBool("IsStoped", false);
        }
        else
        {
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Walking"))
            {
                anim.SetBool("IsStoped", true);
            }
            anim.SetBool("IsWalking", false);
        }
    }

    bool IsGrounded()
    {
        return Physics.Raycast(rb.transform.position, -Vector3.up, distanceToFeet + 1.0f);
    }

    public void OutOfWorld()
    {
        if (this.transform.position.y <= -150)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}