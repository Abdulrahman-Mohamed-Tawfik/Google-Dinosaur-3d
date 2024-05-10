using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AiPlayer : MonoBehaviour
{
    public Transform target;
    public float speed;
    public float minDistance;
    [SerializeField] private Animator animator;
    public GameObject projectile;
    private PlayerController playerController;
    private float NextShootTime;
    public float TimeBetweenShoots;
    private bool TrexHasEaten = false;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.FindObjectOfType<PlayerController>();
        TrexHasEaten = false;
    }
    // void FixedUpdate()
    // {
    //     speed += 0.5f;
    // }
    // Update is called once per frame
    void Update()
    {
        if (playerController.isAlive)
        {
            if (playerController.Score >= 7||playerController.CoinScore >= 10)
            {
                if (Time.time > NextShootTime)
                {
                    Instantiate(projectile, transform.position, Quaternion.identity);
                    NextShootTime = Time.time + TimeBetweenShoots;
                }
            }
            if (Vector3.Distance(transform.position, target.position) > minDistance)
                transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            // else
            //     animator.Play("Attack1");
            // speed += 1;
            // speed = Math.Abs(playerController.FWDAndLRSpeed)+30;
        }
        else
        {
            if (!TrexHasEaten)
            {
                minDistance = 0;
                transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                if (transform.position == target.position)
                {
                    animator.Play("Eat");
                    TrexHasEaten = true;
                }
            }
        }
    }

}
