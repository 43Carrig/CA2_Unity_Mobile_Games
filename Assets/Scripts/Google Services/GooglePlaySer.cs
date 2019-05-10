//using UnityEngine;
//using GooglePlayGames;
//using GooglePlayGames.BasicApi;

//// https://www.youtube.com/watch?v=5Ae8GeRmdH0&ab_channel=ResoCoder // Google Play Developer Console

//public class GooglePlaySer : MonoBehaviour
//{
//    // Use this for initialization
//    void Start () {
//        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
//        PlayGamesPlatform.InitializeInstance(config);
//        PlayGamesPlatform.Activate();
 
//        SignIn();
//    }
 
//    void SignIn()
//    {
//        Social.localUser.Authenticate(success => { });
//    }
 
//    #region Achievements
//    public static void UnlockAchievement(string id)
//    {
//        Social.ReportProgress(id, 100, success => { });
//    }
 
//    public static void IncrementAchievement(string id, int stepsToIncrement)
//    {
//        PlayGamesPlatform.Instance.IncrementAchievement(id, stepsToIncrement, success => { });
//    }
 
//    public static void ShowAchievementsUI()
//    {
//        Social.ShowAchievementsUI();
//    }
//    #endregion /Achievements
 
//    #region Leaderboards
//    public static void AddScoreToLeaderboard(string leaderboardId, long score)
//    {
//        Social.ReportScore(score, leaderboardId, success => { });
//    }
 
//    public static void ShowLeaderboardsUI()
//    {
//        Social.ShowLeaderboardUI();
//    }
//    #endregion /Leaderboards
//}
