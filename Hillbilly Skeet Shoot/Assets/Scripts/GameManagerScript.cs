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
    public TextMeshProUGUI scoreText2;
    public TextMeshProUGUI highScoreText2;

    public static int lives = 3;
    public GameObject[] livesUI;

    public GameObject playScreen;
    public GameObject gameOverScreen;

    // Start is called before the first frame update
    void Start()
    {
        highScoreText.text = "Highscore: " + PlayerPrefs.GetInt(HighScore);
        playScreen.SetActive(true);
        gameOverScreen.SetActive(false);
        Time.timeScale = 1;
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
        playScreen.SetActive(false);
        gameOverScreen.SetActive(true);
        scoreText2.text = "Score: " + score;
        highScoreText2.text = "Highscore: " + PlayerPrefs.GetInt(HighScore);
        Time.timeScale = 0;
    }

    //buttons
    public void LoadSceneButton(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        //Look up reload scene
    }
}
