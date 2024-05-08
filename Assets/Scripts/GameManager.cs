using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{

    public static GameManager MyInstance;
    public GameObject GameOverPanel;

    public TextMeshPro coins_score;
    public int c_s;
    private void Awake()
    {
        MyInstance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        GameOverPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //coins_score.text = c_s.ToString();
    }
    public void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
