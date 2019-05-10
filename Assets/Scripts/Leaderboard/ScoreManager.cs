


// Reference: Unity Leaderboard - https://www.youtube.com/watch?v=6ik8pK1GGh4 

using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;    
    
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = AppManager.Instance.mScore.ToString();
    }

    public void ShowLeaderBoard()
    {
        AppManager.Instance.ShowLeaderboardUI();
    }

    public void PostToLeaderboard(int score)
    {
        if (AppManager.Instance.Authenticated && score > AppManager.Instance.mHighestPostedScore)
        {
            // post score to the leaderboard
            Social.ReportScore(score, GPGSIds.leaderboard_high_score, (bool success) => { });
            AppManager.Instance.mHighestPostedScore = score;
        }
        else
        {
            Debug.LogWarning("Not reporting score, auth = " + AppManager.Instance.Authenticated + " " +
                             score + " <= " + AppManager.Instance.mHighestPostedScore);
            scoreText.text = "Not reporting score, auth = " + AppManager.Instance.Authenticated + " " +
                             score + " <= " + AppManager.Instance.mHighestPostedScore;
        }
    }
    
    public void SubmitScore()
    {
        AppManager.Instance.mScore += 1;
        scoreText.text = AppManager.Instance.mScore.ToString();
        PostToLeaderboard(AppManager.Instance.mScore);
        AppManager.Instance.CheckAchievements();
    }
}
