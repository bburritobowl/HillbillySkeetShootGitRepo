using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManagerScript : MonoBehaviour
{
    public int highScore;
    private string HighScore =  "HighScore";
    private string Score = "Score";
    public int score = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public int lives = 3;
    public GameObject[] livesUI;

    public GameObject playScreen;
    public GameObject pauseScreen;

    public AdScript adScript;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        highScoreText.text = "Highscore: " + PlayerPrefs.GetInt(HighScore);
        playScreen.SetActive(true);
        pauseScreen.SetActive(false);
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
        if(lives <= 0)
        {
            GameOver();
        }
        livesUI[lives].SetActive(false);
    }

    public void GameOver()
    {
        PlayerPrefs.SetInt(Score, score);
        adScript.ShowInterstitialAd(); //play ad
        SceneManager.LoadScene("GameOverScene");
    }

    //buttons
    public void LoadSceneButton(string sceneName)
    {
        adScript.ShowInterstitialAd();
        SceneManager.LoadScene(sceneName);
    }
    public void PauseGame()
    {
        pauseScreen.SetActive(true);
        playScreen.SetActive(false);
        Time.timeScale = 0;
    }
    public void Resume()
    {
        pauseScreen.SetActive(false);
        playScreen.SetActive(true);
        Time.timeScale = 1;
    }
}
