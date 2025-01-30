using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject creditsPanel;


    private void Awake()
    {
        menuPanel.SetActive(true);
        creditsPanel.SetActive(false);
    }
   
    

    public void GoToCreditsPanel()
    {
        creditsPanel.SetActive(true);
    }

    public void GoBack()
    {
        creditsPanel.SetActive(false);
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
