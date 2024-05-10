using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Vector3 targetPos;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        targetPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        targetPos.z += 100;//aim ahead of player
    }

    // void FixedUpdate()
    // {
    //     speed += 1;
    // }
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if (transform.position == targetPos)
        {
            Destroy(gameObject, 2f);
        }
    }
}
