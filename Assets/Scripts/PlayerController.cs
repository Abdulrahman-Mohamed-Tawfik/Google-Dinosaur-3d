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
    public long Score;
    public Rigidbody rb;
    public AudioSource audioplayer;


    float horizontalInput;
    [SerializeField] private Animator animator;
    string[] deadlyObjects = { "Cactus1", "Cactus2", "ShaneR", "SahneL","ptera_LOD_0", "DragonMesh" };
    public TextMeshProUGUI scoreTextMesh;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        // scoreTextMesh = GetComponent<TextMeshProUGUI>();
        Score = 0;
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
       // Score = (long)Mathf.Abs(FWDAndLRSpeed) - 30;
        // Debug.Log(isGrounded);
        // Debug.Log("Move Speed: " + Mathf.Abs(Run_and_move_Speed));
        // Debug.Log("Score: " + Score);
        scoreTextMesh.text = ("Score: " + Score);

        if (Mathf.Abs(FWDAndLRSpeed) % 50 == 0)
        {
            animator.SetFloat("RunAnimSpeed", RunAnimSpeed);
            animator.SetFloat("JumbAnimSpeed", JumpAnimSpeed);
            RunAnimSpeed += 0.2f;
            JumpAnimSpeed += 0.2f;
        }

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && isGrounded)
        {
            Jump();
            // rb.AddForce(Physics.gravity * (gravityScale - 1) * rb.mass);
            Debug.Log("jumped");
        }
    }
    private void Jump()
    {
        animator.Play("jumb");
        isGrounded = false;
    }

    private void OnCollisionEnter(Collision collisioninfo)
    {
        if (collisioninfo.gameObject.name.Contains("coin"))
        {
            Destroy(collisioninfo.gameObject);
            Score += 1;
           
        }



        if (collisioninfo.collider.name == "Ground")
        {
            isGrounded = true;
        }
        foreach (string deadlyObjectName in deadlyObjects)
        {
            if (collisioninfo.collider.name == deadlyObjectName)
            {
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
        GameManager.MyInstance.GameOverPanel.SetActive(true);
    }
}
