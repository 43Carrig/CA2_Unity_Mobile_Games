using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;
using GoogleMobileAds;
using GoogleMobileAds.Api;
using System;
using UnityEngine.UI;

//using UnityEditor.Advertisements;

public class ButtonManager : MonoBehaviour 
{
    
    private BannerView bannerView;
    private InterstitialAd interstitial;
//    private NativeExpressAdView nativeExpressAdView;
    private RewardBasedVideoAd rewardBasedVideo;
    public Text textBox;
    
    //**********************************************************************
    //Creating a Start Menu / Main Menu - https://www.youtube.com/watch?v=FrJogRBSzFo 
    public void NewGameBtn(string newGameLevel)
    {
        SceneManager.LoadScene(newGameLevel);
    }

    public void ExitGameBtn()
    {
        Application.Quit();
    }
    
    //**********************************************************************
    #region Request Unity Video Ad
    //N3K EN - Implementing Unity AD services tutorial reference: https://www.youtube.com/watch?v=7LFF4S9IYKM&ab_channel=N3KEN 
    public void ShowUnityAd()
    {
        //Advertisement.Show();
        if (Advertisement.IsReady())
        {
            Advertisement.Show("video", new ShowOptions() { resultCallback = HandleAdResult });
        }
    }
    private void HandleAdResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("Player Watched the AD!");
                break;

            case ShowResult.Skipped:
                Debug.Log("Player Didn't fully Watch the AD!");
                break;

            case ShowResult.Failed:
                Debug.Log("Player failed to launch the Ad! No internet connection?");
                break;
        }
    } 
    #endregion

    //*************************************************************************************
    
    // Integrate Google Mobile Ads Admob with Unity - https://www.youtube.com/watch?v=iWom-lXlkkk&ab_channel=AkbarChannel
    
    public void Start()
    {

        #if UNITY_ANDROID
                string appId = "ca-app-pub-3098190773030829~9506109197";
        #elif UNITY_IPHONE
                    string appId = "ca-app-pub-3940256099942544~1458002511";
        #else
                    string appId = "unexpected_platform";
        #endif

        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(appId);

        this.rewardBasedVideo = RewardBasedVideoAd.Instance;
        
        if(textBox != null) textBox.text = AppManager.Instance.Authenticate();
    }
    
    private AdRequest CreateAdRequest()
    {
        return new AdRequest.Builder()
            //.AddTestDevice(AdRequest.TestDeviceSimulator)
            //.AddTestDevice("0123456789ABCDEF0123456789ABCDEF")
            //.AddKeyword("game")
            //.SetGender(Gender.Male)
            //.SetBirthday(new DateTime(1985, 1, 1))
            //.TagForChildDirectedTreatment(false)
            //.AddExtra("color_bg", "9B30FF")
            .Build();
    }

    public void DestroyBanner()
    {
        if (this.bannerView != null)
        {
            this.bannerView.Destroy();
        }
    }

    //public void DestroyNative()
    //{
    //    if (this.nativeExpressAdView != null)
    //    {
    //        this.nativeExpressAdView.Destroy();
    //    }
    //}

    public void RequestBanner()
    {
                // These ad units are configured to always serve test ads.
        #if UNITY_EDITOR
                string adUnitId = "unused";
        #elif UNITY_ANDROID
                string adUnitId = "ca-app-pub-3940256099942544/6300978111"; // test: ca-app-pub-3940256099942544/6300978111
        #elif UNITY_IPHONE
                string adUnitId = "ca-app-pub-3940256099942544/2934735716";
        #else
                string adUnitId = "unexpected_platform";
        #endif

        // Clean up banner ad before creating a new one.
        if (this.bannerView != null)
        {
            this.bannerView.Destroy();
        }

        // Create a 320x50 banner at the top of the screen.
        this.bannerView = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Top);

        // Register for ad events.
        this.bannerView.OnAdLoaded += this.HandleAdLoaded;
        this.bannerView.OnAdFailedToLoad += this.HandleAdFailedToLoad;
        this.bannerView.OnAdOpening += this.HandleAdOpened;
        this.bannerView.OnAdClosed += this.HandleAdClosed;
        this.bannerView.OnAdLeavingApplication += this.HandleAdLeftApplication;

        // Load a banner ad.
        this.bannerView.LoadAd(this.CreateAdRequest());
    }

    public void RequestInterstitial()
    {
            // These ad units are configured to always serve test ads.
        #if UNITY_EDITOR
                string adUnitId = "unused";
        #elif UNITY_ANDROID
                string adUnitId = "ca-app-pub-3940256099942544/1033173712"; // test: ca-app-pub-3940256099942544/1033173712
        #elif UNITY_IPHONE
                string adUnitId = "ca-app-pub-3940256099942544/4411468910";
        #else
                string adUnitId = "unexpected_platform";
        #endif

        // Clean up interstitial ad before creating a new one.
        if (this.interstitial != null)
        {
            this.interstitial.Destroy();
        }

        // Create an interstitial.
        this.interstitial = new InterstitialAd(adUnitId);

        // Register for ad events.
        this.interstitial.OnAdLoaded += this.HandleInterstitialLoaded;
        this.interstitial.OnAdFailedToLoad += this.HandleInterstitialFailedToLoad;
        this.interstitial.OnAdOpening += this.HandleInterstitialOpened;
        this.interstitial.OnAdClosed += this.HandleInterstitialClosed;
        this.interstitial.OnAdLeavingApplication += this.HandleInterstitialLeftApplication;

        // Load an interstitial ad.
        this.interstitial.LoadAd(this.CreateAdRequest());
    }
    
    //    public void RequestNativeExpressAdView()
    //    {
    //        // These ad units are configured to always serve test ads.
    //#if UNITY_EDITOR
    //        string adUnitId = "unused";
    //#elif UNITY_ANDROID
    //        string adUnitId = "ca-app-pub-3940256099942544/1072772517";
    //#elif UNITY_IPHONE
    //        string adUnitId = "ca-app-pub-3940256099942544/2562852117";
    //#else
    //        string adUnitId = "unexpected_platform";
    //#endif

    //    // Clean up native express ad before creating a new one.
    //    if (this.nativeExpressAdView != null)
    //    {
    //        this.nativeExpressAdView.Destroy();
    //    }

    //    // Create a 320x150 native express ad at the top of the screen.
    //    this.nativeExpressAdView = new NativeExpressAdView(
    //        adUnitId,
    //        new AdSize(320, 150),
    //        AdPosition.Top);

    //    // Register for ad events.
    //    this.nativeExpressAdView.OnAdLoaded += this.HandleNativeExpressAdLoaded;
    //    this.nativeExpressAdView.OnAdFailedToLoad += this.HandleNativeExpresseAdFailedToLoad;
    //    this.nativeExpressAdView.OnAdOpening += this.HandleNativeExpressAdOpened;
    //    this.nativeExpressAdView.OnAdClosed += this.HandleNativeExpressAdClosed;
    //    this.nativeExpressAdView.OnAdLeavingApplication += this.HandleNativeExpressAdLeftApplication;

    //    // Load a native express ad.
    //    this.nativeExpressAdView.LoadAd(this.CreateAdRequest());
    //}
    
    public void RequestRewardBasedVideo()
    {
        #if UNITY_EDITOR
                string adUnitId = "unused";
        #elif UNITY_ANDROID
                string adUnitId = "ca-app-pub-3940256099942544/5224354917"; // test: ca-app-pub-3940256099942544/5224354917
        #elif UNITY_IPHONE
                string adUnitId = "ca-app-pub-3940256099942544/1712485313";
        #else
                string adUnitId = "unexpected_platform";
        #endif

        // Called when an ad request has successfully loaded.
        rewardBasedVideo.OnAdLoaded += HandleRewardBasedVideoLoaded;
        // Called when an ad request failed to load.
        rewardBasedVideo.OnAdFailedToLoad += HandleRewardBasedVideoFailedToLoad;

        this.rewardBasedVideo.LoadAd(this.CreateAdRequest(), adUnitId);
    }

    public void HandleRewardBasedVideoLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoLoaded event received");
    }

    public void HandleRewardBasedVideoFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardBasedVideoFailedToLoad event received with message: "
                             + args.Message);
    }

    public void ShowRewardAd()
    {
        if (this.rewardBasedVideo.IsLoaded())
        {
            this.rewardBasedVideo.Show();
        }
        else
        {
            MonoBehaviour.print("rewardBasedVideo is not ready yet");
        }
    }

    public void ShowInterstitial()
    {
        if (this.interstitial.IsLoaded())
        {
            this.interstitial.Show();
        }
        else
        {
            MonoBehaviour.print("Interstitial is not ready yet");
        }
    }

    public void ShowAchievementUI()
    {
        AppManager.Instance.ShowAchievementsUI();
    }
    
    #region Banner callback handlers

    public void HandleAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLoaded event received");
    }

    public void HandleAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print("HandleFailedToReceiveAd event received with message: " + args.Message);
    }

    public void HandleAdOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpened event received");
    }

    public void HandleAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdClosed event received");
    }

    public void HandleAdLeftApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLeftApplication event received");
    }

    #endregion

    #region Interstitial callback handlers

    public void HandleInterstitialLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleInterstitialLoaded event received");
       
    }

    public void HandleInterstitialFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print(
            "HandleInterstitialFailedToLoad event received with message: " + args.Message);
    }

    public void HandleInterstitialOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleInterstitialOpened event received");
    }

    public void HandleInterstitialClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleInterstitialClosed event received");
    }

    public void HandleInterstitialLeftApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleInterstitialLeftApplication event received");
    }

    #endregion

    #region Native express ad callback handlers

    public void HandleNativeExpressAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleNativeExpressAdAdLoaded event received");
    }

    public void HandleNativeExpresseAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print(
            "HandleNativeExpressAdFailedToReceiveAd event received with message: " + args.Message);
    }

    public void HandleNativeExpressAdOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleNativeExpressAdAdOpened event received");
    }

    public void HandleNativeExpressAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleNativeExpressAdAdClosed event received");
    }

    public void HandleNativeExpressAdLeftApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleNativeExpressAdAdLeftApplication event received");
    }

    #endregion
    
}
