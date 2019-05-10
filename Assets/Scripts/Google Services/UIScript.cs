//using UnityEngine;
//using UnityEngine.UI;
 
//// https://www.youtube.com/watch?v=5Ae8GeRmdH0&ab_channel=ResoCoder // Google Play Developer Console

//// Android, Google Play Services and Google Play Console - https://www.youtube.com/watch?v=AWawL5HFn64&t=391s

//// Unity-Setting up Google Play Services and Google Play Console (2018) - https://www.youtube.com/watch?v=PXqNN6Y-zpw

//public class UIScript : MonoBehaviour {
 
//    public static UIScript Instance { get; private set; }
 
//    // Use this for initialization
//    void Start () {
//        Instance = this;
//    }
 
//    [SerializeField]
//    private Text pointsTxt;
 
//    public void GetPoint()
//    {
//        ManagerScript.Instance.IncrementCounter();
//    }
 
//    public void Restart()
//    {
//        ManagerScript.Instance.RestartGame();
//    }
 
//    public void Increment()
//    {
//        GooglePlaySer.IncrementAchievement(GPGSIds.achievement_incremental_achievement, 5);
//    }
 
//    public void Unlock()
//    {
//        GooglePlaySer.UnlockAchievement(GPGSIds.achievement_standard_achievement);
//    }
 
//    public void ShowAchievements()
//    {
//        GooglePlaySer.ShowAchievementsUI();
//    }
 
//    public void ShowLeaderboards()
//    {
//        GooglePlaySer.ShowLeaderboardsUI();
//    }
 
//    public void UpdatePointsText()
//    {
//        pointsTxt.text = ManagerScript.Counter.ToString();
//    }
//}