

// Reference: Unity Achievement - https://www.youtube.com/watch?v=v-ITInk5HLY

using UnityEngine;
using UnityEngine.UI;

public class ScoreManagerAchieve : MonoBehaviour
{
    public Text scoreText;
    private int score;
    
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = AppManager.Instance.mScore.ToString();
    }
    public void ClickScore()
    {
        score += 1;
        scoreText.text = score.ToString();

        /*if (score == 3)
        {
            Achievements.Beginner.Unlock();
            Debug.LogWarning("Unlocked beginner");
        }
        else if (score == 10)
        {
            Achievements.Expert.Unlock();
            Debug.LogWarning("Unlocked Expert");
        }*/
    }
}
