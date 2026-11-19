using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManagement : MonoBehaviour
{
    public static ScoreManagement instance;

    public TMP_Text scoreText;
    public TMP_Text highScoreText;

    int score = 0;
    int highScore = 0;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        highScore = PlayerPrefs.GetInt("HighScore", highScore);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreText.text = score.ToString() + " PINS";
        highScoreText.text = "HIGHSCORE: " + highScore.ToString();
    }

    // Update is called once per frame
    public void AddPoint(int points)
    {
        score += points;
        scoreText.text = score.ToString() + " PINS";

        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }
        highScoreText.text = "HIGHSCORE: " + highScore.ToString();
    }
}