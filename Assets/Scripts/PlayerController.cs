using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float gravityScale = 6;
    public bool isAlive = true;
    public bool isGrounded;
    public float RunSpeed;
    public float HorizontalSpeed;
    public Rigidbody rb;
    public float speedIncreaseRate = 1.0f; // Rate at which speed increases

    float horizontalInput;
    // [SerializeField] private float JumpForce = 150;
    // [SerializeField] private LayerMask GroundMask;
    private Animator animator;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator=GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (isAlive)
        {
            // Increase speed gradually(-ve for opposite direction)
            RunSpeed -= Time.fixedDeltaTime * speedIncreaseRate;

            Vector3 forwardMovement = transform.forward * RunSpeed * Time.fixedDeltaTime;
            Vector3 horizontalmovement = transform.right * horizontalInput * HorizontalSpeed * Time.fixedDeltaTime;
            rb.MovePosition(rb.position + forwardMovement + horizontalmovement);
        }
    }

    private void Update()
    {
        rb.AddForce(Physics.gravity * (gravityScale - 1) * rb.mass);
        horizontalInput = Input.GetAxis("Horizontal");
        // float playerHeight = GetComponent<Collider>().bounds.size.y;
        // bool isGrounded = Physics.Raycast(transform.position, Vector3.down, (playerHeight / 2) + 0.1f, GroundMask);

        Debug.Log(isGrounded);
        // Debug.Log("Run Speed="+RunSpeed);

        if (Input.GetKeyDown(KeyCode.W)&& isGrounded)
        {
            Jump();
            // rb.AddForce(Physics.gravity * (gravityScale - 1) * rb.mass);
            Debug.Log("jumped");
        }
    }
    private void Jump()
    {
        // rb.AddForce(new Vector3(0, JumpForce, 10), ForceMode.VelocityChange);
        animator.Play("jumb");
        isGrounded = false;
    }

    private void OnCollisionEnter(Collision collisioninfo)
    {
        if (collisioninfo.collider.name == "Ground")
        {
            isGrounded = true;
        }
        if (collisioninfo.collider.name == "Cactus1" || collisioninfo.collider.name == "Cactus2")
        {
            Dead();
        }
    }

    public void Dead()
    {
        isAlive = false;
        GameManager.MyInstance.GameOverPanel.SetActive(true);
    }
}
