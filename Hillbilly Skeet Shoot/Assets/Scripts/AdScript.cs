using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdScript : MonoBehaviour
{
    // android: 4687102
    // apple: 4687103
    string gameId = "4687102";
    bool testMode = true;

    /*#if UNITY_IOS
        private string gameId = "4687103";
    #elif UNITY_ANDROID
        private string gameId = "4687102";
    #endif*/

    void Start()
    {
        // Initialize the Ads service:
        // Advertisement.Initialize(gameId);
        Advertisement.Initialize(gameId, testMode);
    }

    public void ShowInterstitialAd()
    {
        // Check if UnityAds ready before calling Show method:
        if (Advertisement.IsReady())
        {
            Advertisement.Show("Level_Restart");
        }

        else
        {
            Debug.Log("Interstitial ad not ready at the moment! Please try again later!");
        }
        //Time.timeScale = 0f;
    }
}
