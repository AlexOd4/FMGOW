using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PointsManager : MonoBehaviour
{
    public static PointsManager instance;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;

    int score = 0;
    int highscore = 0;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0);
        scoreText.text = score.ToString("0000");
        highscoreText.text = highscore.ToString();
    }

    public void AddPoint10()
    {
        score += 10;
        scoreText.text = score.ToString("0000");
        if (highscore < score)
            PlayerPrefs.SetInt("highscore", score);
    }

    public void AddPoint20()
    {
        score += 20;
        scoreText.text = score.ToString("0000");
        if (highscore < score)
            PlayerPrefs.SetInt("highscore", score);
    }

    public void AddPoint50()
    {
        score += 50;
        scoreText.text = score.ToString("0000");
        if (highscore < score)
            PlayerPrefs.SetInt("highscore", score);
    }
}
