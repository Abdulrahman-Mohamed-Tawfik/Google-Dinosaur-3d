using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float gravityScale = 6;
    public bool isAlive = true;
    public bool isGrounded;
    public float FWDAndLRSpeed=-30;
    public float speedIncreaseRate = 1.0f; // Rate at which speed increases
    public float RunAnimSpeed = 1.6f;
    public float JumpAnimSpeed = 2;
    public long Score = 0;
    public Rigidbody rb;
    

    float horizontalInput;
    // [SerializeField] private float JumpForce = 150;
    // [SerializeField] private LayerMask GroundMask;
    [SerializeField] private Animator animator;
    // public int speedup1=100, speedup2=300, speedup3=500,speedup4=700;
    // public int speedup1 = 30, speedup2 = 50, speedup3 = 60, speedup4 = 70;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
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
        Debug.Log("Score: " + Score);

        // if (Mathf.Abs(Run_and_move_Speed) > speedup1 && Mathf.Abs(Run_and_move_Speed) < speedup2)
        //     animator.SetInteger("Speed", 0);

        // else if (Mathf.Abs(Run_and_move_Speed) >= speedup2 && Mathf.Abs(Run_and_move_Speed) < speedup3)
        //     animator.SetInteger("Speed", 1);

        // else if (Mathf.Abs(Run_and_move_Speed) >= speedup3 && Mathf.Abs(Run_and_move_Speed) < speedup4)
        //     animator.SetInteger("Speed", 2);

        // else 
        //     animator.SetInteger("Speed", 3);
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
        // rb.AddForce(new Vector3(0, JumpForce, 10), ForceMode.VelocityChange);
        // if (animator.GetInteger("Speed") == 0)
        //     animator.Play("jumb");

        // else if (animator.GetInteger("Speed") == 1)
        //     animator.Play("jumb2");

        // else if (animator.GetInteger("Speed") == 2)
        //     animator.Play("jumb3");

        // else if (animator.GetInteger("Speed") == 3)
        //     animator.Play("jumb4");
        animator.Play("jumb");
        isGrounded = false;
    }

    private void OnCollisionEnter(Collision collisioninfo)
    {
        if (collisioninfo.collider.name == "Ground")
        {
            isGrounded = true;
        }
        if (collisioninfo.collider.name == "Cactus1" || collisioninfo.collider.name == "Cactus2" || collisioninfo.collider.name == "ShaneR" || collisioninfo.collider.name == "SahneL")
        {

            Dead();
        }
    }

    public void Dead()
    {
        animator.Play("die1");
        isAlive = false;
        GameManager.MyInstance.GameOverPanel.SetActive(true);
    }
}
