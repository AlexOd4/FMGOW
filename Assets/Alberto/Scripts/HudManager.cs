using UnityEngine;
using UnityEngine.SceneManagement;

public class HudManager : MonoBehaviour
{

    [SerializeField] private GameObject MenuPanel;
    [SerializeField] private GameObject CreditsPanel;
    private bool isMenuActive = false;

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    private void Start()
    {
        CreditsPanel.SetActive(false);
        MenuPanel.SetActive(true);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            alternarMenu();
        }
    }

    public void ChangeScene(string nombreEscena)
    {
        SceneManager.LoadScene(sceneName: nombreEscena);
    }
    public void PararTiempo()
    {
        Time.timeScale = 0.0f;
    }

    public void ContinuarTiempo()
    {
        Time.timeScale = 1.0f;
    }

    public void alternarMenu()
    {
        if (isMenuActive)
        {
            MenuPanel.SetActive(false);
            CreditsPanel.SetActive(true);
            isMenuActive = false;
        }
        else
        {
            MenuPanel.SetActive(true);
            CreditsPanel.SetActive(false);
            isMenuActive = true;
        }
    }
}
