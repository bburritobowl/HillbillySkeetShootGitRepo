using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManagerScript : MonoBehaviour
{
    public static int highScore;
    private string HighScore =  "HighScore";
    public static int score = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    public static int lives = 3;
    public GameObject[] livesUI;

    public GameObject playScreen;
    public GameObject gameOverScreen;

    // Start is called before the first frame update
    void Start()
    {
        highScoreText.text = "Highscore: " + PlayerPrefs.GetInt(HighScore);
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score;
        if(PlayerPrefs.GetInt(HighScore) < score)
        {
            PlayerPrefs.SetInt(HighScore, score);
            highScoreText.text = "Highscore: " + PlayerPrefs.GetInt(HighScore);
        }
    }

    public void LoseALife()
    {
        lives--;
        livesUI[lives].SetActive(false);
        if(lives <= 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {

    }
}
