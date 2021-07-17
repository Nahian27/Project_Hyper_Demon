using UnityEngine;
using UnityEngine.UI;

public class HUD_Script : MonoBehaviour
{
    public Text scoreText;
    public static int score = 0;
    public GameOver_Script FinalScore;

    private void Start()
    {
        score = 0;
    }
    private void OnGUI()
    {
        scoreText.text = score.ToString();
        FinalScore.Setup(score);
    }
}