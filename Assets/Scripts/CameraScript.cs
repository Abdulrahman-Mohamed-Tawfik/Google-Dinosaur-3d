using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public GameObject Camera1;
    public GameObject Camera2;
    public GameObject Camera3;
    public GameObject Camera4;
    public GameObject Camera5;

    void Start()
    {
        CameraOne();
    }
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            CameraOne();
        }

        if (Input.GetKeyDown("2"))
        {
            CameraTwo();
        }

        if (Input.GetKeyDown("3"))
        {
            CameraThree();
        }
        if (Input.GetKeyDown("4"))
        {
            CameraFour();
        }
        if (Input.GetKeyDown("5"))
        {
            CameraFive();
        }
    }

    void CameraOne()
    {
        Camera5.SetActive(false);
        Camera4.SetActive(false);
        Camera3.SetActive(false);
        Camera2.SetActive(false);
        Camera1.SetActive(true);
    }

    void CameraTwo()
    {
        Camera5.SetActive(false);
        Camera4.SetActive(false);
        Camera3.SetActive(false);
        Camera2.SetActive(true);
        Camera1.SetActive(false);
    }

    void CameraThree()
    {
        Camera5.SetActive(false);
        Camera4.SetActive(false);
        Camera3.SetActive(true);
        Camera2.SetActive(false);
        Camera1.SetActive(false);
    }
    void CameraFour()
    {
        Camera5.SetActive(false);
        Camera4.SetActive(true);
        Camera3.SetActive(false);
        Camera2.SetActive(false);
        Camera1.SetActive(false);
    }
    void CameraFive()
    {
        Camera5.SetActive(true);
        Camera4.SetActive(false);
        Camera3.SetActive(false);
        Camera2.SetActive(false);
        Camera1.SetActive(false);
    }
}
