using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using System;

public class Ads : MonoBehaviour, IUnityAdsShowListener, IUnityAdsLoadListener, IUnityAdsInitializationListener, IUnityAdsListener
{
    [SerializeField] BannerPosition _bannerPosition = BannerPosition.BOTTOM_CENTER;
    [SerializeField] int playerRewardAmount = 1;
    
    public static Ads adsManager;
    public string rewardedVideo = "Rewarded_Android";
    public string interstitial_Android = "Interstitial_Android";
    public string banner_Android = "Banner_Android";
    public bool testMode = true;

#if UNITY_IOS
    public string gameId = "4812956";
#elif UNITY_ANDROID
    public  string gameId = "4812957";
#endif



    private void Start()
    {
        Advertisement.Initialize(gameId, testMode);
        Advertisement.AddListener(this);
        BannerAd();
    }

    public void PlayInterstitial()
    {
        if (Advertisement.IsReady("Interstitial_Android"))
        {
            Advertisement.Show("Interstitial_Android");
        }
        else
        {
            Debug.Log("Unkown Error Occurred");
        }
    }

    IEnumerator RepeatShowBanner()
    {
        yield return new WaitForSeconds(1);
        BannerAd();
    }
    public void BannerAd()
    {
        if (Advertisement.IsReady("Banner_Android"))
        {
            Advertisement.Banner.SetPosition(_bannerPosition);
            Advertisement.Show("Banner_Android");
        }
        else
        {
            StartCoroutine(RepeatShowBanner());
        }
    }

    public void PlayRewarded()
    {
        if (Advertisement.IsReady("Rewarded_Android"))
        {
            Advertisement.Show("Rewarded_Android");
           
        }
        else
        {
            Debug.Log("Ad is not ready");
        }


    }


    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Debug.Log("ads failed to show");
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        Debug.Log("ads show start" + placementId);
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        throw new NotImplementedException();
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        
       if(placementId == rewardedVideo && showCompletionState== UnityAdsShowCompletionState.COMPLETED)
        {

            Debug.Log("reward player");
            SwipeCounter._instance.DeactivateGameOverScreen();
            PauseMenu._instance.EnablePlayerControls();
            PauseMenu._instance.EnableYellowJoiner();

                

        }
        else if (placementId == rewardedVideo && showCompletionState == UnityAdsShowCompletionState.SKIPPED)
        {
            Debug.Log("Player doesn't get rewarded");
        } 
        else if (placementId == rewardedVideo && showCompletionState == UnityAdsShowCompletionState.UNKNOWN)
        {
            Debug.Log("Unkown Error Occurred");
        }
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        Debug.Log("ads loaded");
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.Log("ads failed");
    }

    public void OnInitializationComplete()
    {
        Debug.Log("Initialization complete");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log("Inititialzation failed: " + message);
    }

    public void OnUnityAdsReady(string placementId)
    {
        Debug.Log("Ads ready" + placementId);
    }

    public void OnUnityAdsDidError(string message)
    {
        Debug.Log("Ads did error " + message);
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        Debug.Log("Ads started" + placementId);
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if(placementId == "Rewarded_Android" && showResult == ShowResult.Finished)
        {
            Debug.Log("reward player");
            SwipeCounter._instance.RewardPlayer(playerRewardAmount);
            SwipeCounter._instance.DeactivateGameOverScreen();
            PauseMenu._instance.EnablePlayerControls();
            PauseMenu._instance.EnableYellowJoiner();

        }
        else if (placementId == "Rewarded_Android" && showResult == ShowResult.Failed)
        {
            Debug.Log("Unkown Error Occurred");
        }
        else if (placementId == "Rewarded_Android" && showResult == ShowResult.Skipped)
        {
            Debug.Log("Player gets no reward");
        }
    }
}
