using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class JesusCLevelManager : MonoBehaviour
{
    //Singleton
    public static JesusCLevelManager Instance; //the object is created

    //Panels
    [Header("Panels")]
    [SerializeField] private GameObject endPanel;
    [SerializeField] private GameObject winPanel;
    [SerializeField] GameObject ballprefab;

    [Header("References")]
    [SerializeField] private TextMeshProUGUI ballUI;

    [Header("Attributes")]
    [SerializeField] private int maxBalls;

    public int balls = 0;
    [HideInInspector] public bool outOfBalls;


   

    private void Awake()
    {
  
        //Singleton, reference Instance to this object instance
        Instance = this;

        //restart TimeScale
        Time.timeScale = 1;
    }

    public void Start()
    {
        UpdateBallUI();
    }


    public void UpdateBallUI()
    {
        balls++;
        ballUI.text = balls + "/" + maxBalls;

    }
    

    private void Update()
    {
       
        if (outOfBalls == true)
        {
            GameOver(); //activate game over when it runs out of balls
        }
               

    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }



    public void WinLevel()
    {
        //Active the panel
        winPanel.SetActive(true);

        //Set time to 0 (PAUSE GAME)
        Time.timeScale = 0;
    }

    public void GameOver()
    {
        //Activate the panel
        endPanel.SetActive(true);

        //Set timeScale to 0 (PAUSE GAME)
        Time.timeScale = 0;
    }

}
