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
    public int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public int lives = 3;
    public GameObject[] livesUI;

    public GameObject playScreen;
    public GameObject pauseScreen;

    public AdScript adScript;
    [SerializeField] Scene currentScene;

    // Start is called before the first frame update
    void Start()
    {
        highScoreText.text = "Highscore: " + PlayerPrefs.GetInt(HighScore);
        playScreen.SetActive(true);
        pauseScreen.SetActive(false);
        Time.timeScale = 1;

        //Check which scene so we know to reset score or not
        currentScene = SceneManager.GetActiveScene();
        if(currentScene.name == "SampleScene");
        {
            score = 0;
            PlayerPrefs.SetInt(Score, 0);
        }
        scoreText.text = "Score: " + PlayerPrefs.GetInt(Score);
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetInt(Score) < score)
        {
            PlayerPrefs.SetInt(Score, score); //make it so that you save the score in playerprefs and then when you load the actual LEVEL (only the level!) it resets to 0
            scoreText.text = "Score: " + PlayerPrefs.GetInt(Score);
            Debug.Log(PlayerPrefs.GetInt(Score));
        }

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
