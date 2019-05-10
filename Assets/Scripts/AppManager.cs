using System;
using System.Collections.Generic;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine;

//Reference: https://github.com/playgameservices/play-games-plugin-for-unity/tree/master/samples/CubicPilot
public class AppManager
{
    private static AppManager sInstance = new AppManager();

    private bool mAuthenticating = false;
    public int mHighestPostedScore { get; set; }
    public int mScore { get; set; }

    // list of achievements we know we have unlocked (to avoid making repeated calls to the API)
    private Dictionary<string, bool> mUnlockedAchievements = new Dictionary<string, bool>();

    // achievement increments we are accumulating locally, waiting to send to the games API
    private Dictionary<string, int> mPendingIncrements = new Dictionary<string, int>();

    public bool Authenticating
    {
        get { return mAuthenticating; }
    }

    public bool Authenticated => Social.Active.localUser.authenticated;

    public static AppManager Instance
    {
        get { return sInstance; }
    }

    private AppManager()
    {
    }


    public void UnlockAchievement(string achId)
    {
        if (Authenticated && !mUnlockedAchievements.ContainsKey(achId))
        {
            Social.ReportProgress(achId, 100.0f, (bool success) => { });
            mUnlockedAchievements[achId] = true;
        }
    }

    public void SignOut()
    {
        ((PlayGamesPlatform) Social.Active).SignOut();
    }

    public void ShowLeaderboardUI()
    {
        if (Authenticated)
        {
            Social.ShowLeaderboardUI();
        }
    }

    public void ShowAchievementsUI()
    {
        if (Authenticated)
        {
            Social.ShowAchievementsUI();
        }
    }
    
    public String Authenticate()
    {
        if (Authenticated || mAuthenticating)
        {
            Debug.LogWarning("Ignoring repeated call to Authenticate().");
            return "Already Authenticated";
        }

        // Enable/disable logs on the PlayGamesPlatform
        PlayGamesPlatform.DebugLogEnabled = true;

        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder()
            //.EnableSavedGames()
            .Build();
        PlayGamesPlatform.InitializeInstance(config);

        // Activate the Play Games platform. This will make it the default
        // implementation of Social.Active
        PlayGamesPlatform.Activate();

        // Set the default leaderboard for the leaderboards UI
        ((PlayGamesPlatform) Social.Active).SetDefaultLeaderboardForUI(GPGSIds.leaderboard_high_score);

        string messageStuff = "";
        
        // Sign in to Google Play Games
        mAuthenticating = true;
        Social.localUser.Authenticate((bool success, string message) =>
        {
            mAuthenticating = false;
            if (success)
            {
                // if we signed in successfully, load data from cloud
                Debug.Log("Login successful!");
                messageStuff = "Successfully authenticated";
            }
            else
            {
                // no need to show error message (error messages are shown automatically
                // by plugin)
                Debug.LogWarning("Failed to sign in with Google Play Games.");
                Debug.LogWarning(message);}

                messageStuff = message;
        });
        return messageStuff;
    }

    public void CheckAchievements()
    {
        if (mScore == 3)
                {
                    Social.ReportProgress(GPGSIds.achievement_beginner, 100.0f, (bool success) =>
                    {
                    });
                    Debug.LogWarning("Unlocked beginner");
                }
                else if (mScore == 10)
                {
                    Social.ReportProgress(GPGSIds.achievement_expert, 100.0f, (bool success) =>
                    {
                    });
                }
    }
}