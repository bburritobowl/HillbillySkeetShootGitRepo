using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Audio;

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

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        highScoreText.text = "Highscore: " + PlayerPrefs.GetInt(HighScore);
        playScreen.SetActive(true);
        pauseScreen.SetActive(false);
        SettingsPanel.SetActive(false);
        areyousurepanel.SetActive(false);
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
        SceneManager.LoadScene("GameOverScene");
    }

    //buttons
    public void LoadSceneButton(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void PauseGame()
    {
        pauseScreen.SetActive(true);
        playScreen.SetActive(false);
        SettingsPanel.SetActive(false);
        Time.timeScale = 0;
    }
    public void Resume()
    {
        pauseScreen.SetActive(false);
        playScreen.SetActive(true);
        Time.timeScale = 1;
    }

    public AudioMixer audioMixerEffects;
    public AudioMixer audioMixerMusic;
    public GameObject SettingsPanel;
    public void setvolumeEffects(float volume)
    {
        audioMixerEffects.SetFloat("volumeeffects", volume);
    }

    public void setvolumeMusic(float volume)
    {
        audioMixerMusic.SetFloat("volumemusic", volume);
    }

    public void settings()
    {
        SettingsPanel.SetActive(true);
       areyousurepanel.SetActive(false);
    }
   public GameObject areyousurepanel;
    public void resetHighscorepressed()
    {
        areyousurepanel.SetActive(true);
    }
    public void areyousureansweryes()
    {
         PlayerPrefs.SetInt(HighScore, 0);
    }

}
