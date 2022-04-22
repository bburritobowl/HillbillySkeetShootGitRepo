using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class mainMenuScript : MonoBehaviour
{
    public GameObject SettingsPanel;
    public GameObject MainMenuPanel;
    public GameObject CuteOpeningScene;

    // Start is called before the first frame update
    void Start()
    {
        CuteOpeningScene.SetActive(true);
        SettingsPanel.SetActive(false);
        MainMenuPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void gobacktomenupane()
    {
        CuteOpeningScene.SetActive(true);
        SettingsPanel.SetActive(false);
        MainMenuPanel.SetActive(false);
    }

    public void PlayGame()
    {
        //to be changed later
        SceneManager.LoadScene("SampleScene");
    }

    public void settings()
    {
        CuteOpeningScene.SetActive(false);
        SettingsPanel.SetActive(true);
        MainMenuPanel.SetActive(false);
    }

    public void OpeningArt()
    {
        //click anywhere to go to main menu panel
        CuteOpeningScene.SetActive(false);
        MainMenuPanel.SetActive(true);
    }

    public void ItemsMenu()
    {
        SceneManager.LoadScene("ItemShelf");
    }

    public void gotomainmenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public AudioMixer audioMixerEffects;
    public AudioMixer audioMixerMusic;
    public void setvolumeEffects(float volume)
    {
        audioMixerEffects.SetFloat("volumeeffects", volume);
    }

    public void setvolumeMusic(float volume)
    {
        audioMixerMusic.SetFloat("volumemusic", volume);
    }

}
