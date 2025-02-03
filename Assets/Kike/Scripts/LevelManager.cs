using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    public static LevelManager main;

    [Header("References")]
    [SerializeField] private TextMeshProUGUI shootUI;

    [SerializeField] private GameObject levelCompleteUI;
    [SerializeField] private TextMeshProUGUI levelCompletedShootUI;

    [SerializeField] private GameObject gameoverUI;
    [SerializeField] private GameObject creditsPanel;
    [SerializeField] private GameObject pausepanel;
    [SerializeField] private AudioSource winAudio;

   

    [Header("Atributtes")]
    [SerializeField] private int maxShoots;

    private int shoots;
    [HideInInspector] public bool outofShoots;
    [HideInInspector] public bool levelCompleted;

    private bool isPaused = false;

    private void Awake()
    {
        main = this;
       
    }

   
    private void Start()
    {
        UpdateShootUI();
        
    }

    public void IncreaseShoot()
    {
        shoots++;
        UpdateShootUI();

        if(shoots >= maxShoots)
        {
            outofShoots = true;
        }
    }

    public void LevelComplete()
    {
        levelCompleted = true;

        levelCompletedShootUI.text = shoots > 1 ? " You did it in " + shoots + " shoots " : "You got a hole in one!";

        levelCompleteUI.SetActive(true);
        winAudio.Play();
    }

    public void GameOver()
    {
        gameoverUI.SetActive(true);
    }
    private void UpdateShootUI()
    {
        shootUI.text = shoots + "/" + maxShoots;

    }

    public void OpenLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ExitCredits()
    {
        creditsPanel.SetActive(false);
    }

    public void OpenCredits()
    {
        creditsPanel.SetActive(true);
    }

    public void PauseGame()
    {
        if (isPaused)
        {
            pausepanel.SetActive(false);
            // Si el juego está pausado, reanudarlo
            Time.timeScale = 1f;
            isPaused = false;
        }
        else
        {
            pausepanel.SetActive(true);
            // Si el juego no está pausado, pausarlo
            Time.timeScale = 0f;
            isPaused = true;
        }
    }
}
