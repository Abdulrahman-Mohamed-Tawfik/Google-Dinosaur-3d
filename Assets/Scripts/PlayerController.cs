using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float gravityScale = 6;
    public bool isAlive = true;
    public bool isGrounded;
    public float FWDAndLRSpeed = -30;
    public float speedIncreaseRate = 1.0f; // Rate at which speed increases
    public float RunAnimSpeed = 1.5f;
    public float JumpAnimSpeed = 2;
    public long CoinScore;
    public long Score;
    private long HIScore = 0;
    public Rigidbody rb;
    public AudioSource src;
    public AudioClip sfxjump, sfxcoin, sfxdie;


    float horizontalInput;
    [SerializeField] private Animator animator;
    string[] deadlyObjects = { "Cactus1", "Cactus2", "SideL", "SideR", "ptera_LOD_0", "Projectile(Clone)" };
    public TextMeshProUGUI scoreTextMesh;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        // scoreTextMesh = GetComponent<TextMeshProUGUI>();
        CoinScore = 0;
        Score = 0;
        HIScore = PlayerPrefs.GetInt("HIScore");
        // HIScore = 0;
        // animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (isAlive)
        {
            // Increase speed gradually(-ve for opposite direction)
            FWDAndLRSpeed -= Time.fixedDeltaTime * speedIncreaseRate;

            Vector3 forwardMovement = transform.forward * FWDAndLRSpeed * Time.fixedDeltaTime;
            Vector3 horizontalmovement = transform.right * horizontalInput * FWDAndLRSpeed * Time.fixedDeltaTime;
            rb.MovePosition(rb.position + forwardMovement + horizontalmovement);
        }
    }

    private void Update()
    {
        rb.AddForce(Physics.gravity * (gravityScale - 1) * rb.mass);
        horizontalInput = Input.GetAxis("Horizontal");
        // float playerHeight = GetComponent<Collider>().bounds.size.y;
        // bool isGrounded = Physics.Raycast(transform.position, Vector3.down, (playerHeight / 2) + 0.1f, GroundMask);
        Score = (long)Mathf.Abs(FWDAndLRSpeed) - 30;
        // Debug.Log(isGrounded);
        // Debug.Log("Move Speed: " + Mathf.Abs(Run_and_move_Speed));
        // Debug.Log("Score: " + Score);
        scoreTextMesh.text = ("HI " + HIScore + " " + Score + " $ " + CoinScore);

        if (Mathf.Abs(FWDAndLRSpeed) % 50 == 0)
        {
            animator.SetFloat("RunAnimSpeed", RunAnimSpeed);
            animator.SetFloat("JumbAnimSpeed", JumpAnimSpeed);
            RunAnimSpeed += 0.2f;
            JumpAnimSpeed += 0.2f;
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            Jump();
            // rb.AddForce(Physics.gravity * (gravityScale - 1) * rb.mass);
            // Debug.Log("jumped");
        }
    }
    private void Jump()
    {
        if (isAlive && isGrounded)
        {
            animator.Play("jump");
            src.clip = sfxjump;
            src.Play();
            isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision collisioninfo)
    {
        if (collisioninfo.gameObject.name.Contains("coin"))
        {
            Destroy(collisioninfo.gameObject);
            CoinScore += 1;
            src.clip = sfxcoin;
            src.Play();

        }



        if (collisioninfo.collider.name == "Ground")
        {
            isGrounded = true;

        }
        if (collisioninfo.collider.name.StartsWith("Cactus") || collisioninfo.collider.name.StartsWith("Rock"))
        {
            if (isAlive)
            {
                src.clip = sfxdie;
                src.Play();
                Dead();
            }
        }
        foreach (string deadlyObjectName in deadlyObjects)
        {
            if (collisioninfo.collider.name == deadlyObjectName && isAlive)
            {
                src.clip = sfxdie;
                src.Play();
                Dead();

                break; // Exit the loop once a deadly object is found
            }
        }
        // Debug.Log(collisioninfo.collider.name);
    }

    public void Dead()
    {
        animator.Play("die1");
        isAlive = false;

        if (Score > PlayerPrefs.GetInt("HIScore"))
        {
            HIScore = Score;
            PlayerPrefs.SetInt("HIScore", (int)HIScore);
        }
        GameManager.MyInstance.GameOverPanel.SetActive(true);
    }
}
