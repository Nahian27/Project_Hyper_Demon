using TMPro;
using UnityEngine;

public class GameOver_Script : MonoBehaviour
{
    public TextMeshProUGUI scoreText, highScoreText;


    public void Setup(int score)
    {
        scoreText.text = "Score " + score.ToString();

        if (score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }

        highScoreText.text = "Highest score " + PlayerPrefs.GetInt("HighScore").ToString();
    }

}
