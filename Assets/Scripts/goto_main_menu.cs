using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goto_main_menu : MonoBehaviour
{
    // Start is called before the first frame update
    public void GotoMainMenu()
    {
        SceneManager.LoadScene("Main_menu");
    }

}
