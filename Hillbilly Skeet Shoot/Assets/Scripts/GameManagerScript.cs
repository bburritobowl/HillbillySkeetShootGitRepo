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
    private string HighScore = "HighScore";
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
        SettingsPanel.SetActive(false);
        areyousurepanel.SetActive(false);
        Time.timeScale = 1;

        scoreText.text = "Score: " + PlayerPrefs.GetInt(Score);
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt(Score) < score)
        {
            PlayerPrefs.SetInt(Score, score);
            scoreText.text = "Score: " + PlayerPrefs.GetInt(Score);
            Debug.Log(PlayerPrefs.GetInt(Score));
        }

        if (PlayerPrefs.GetInt(HighScore) < score)
        {
            PlayerPrefs.SetInt(HighScore, score);
            highScoreText.text = "Highscore: " + PlayerPrefs.GetInt(HighScore);
        }
    }

    public void LoseALife()
    {
        lives--;
        if (lives <= 0)
        {
            GameOver();
        }
        livesUI[lives].SetActive(false);
    }

    public void GameOver()
    {
        //PlayerPrefs.SetInt(Score, score);
        adScript.ShowInterstitialAd(); //play ad
        SceneManager.LoadScene("GameOverScene");
    }

    //buttons
    public void LoadSceneButton(string sceneName)
    {
        adScript.ShowInterstitialAd();
        SceneManager.LoadScene(sceneName);
        ResetScore();
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("MainLevel");
        ResetScore();
    }

    public void ResetScore()
    {
        //Check which scene so we know to reset score or not
        currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "MainLevel") ; ///This is the part that's messing up. it activates when the ads do and idk how to work around that
        {
            Debug.Log("This shouldn't be running unless we're in the main level");
            score = 0;
            PlayerPrefs.SetInt(Score, 0);
        }
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
