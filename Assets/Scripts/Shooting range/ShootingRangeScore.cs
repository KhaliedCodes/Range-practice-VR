
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.UI;

public class ShootingRangeScore : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Reference to a UI Text element to display score
    private int score = 0;
    public static ShootingRangeScore instance;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }



    public void UpdateScoreText()
    {
        score++;
        scoreText.text = "Score: " + score;
    }

    public void UpdateDoubleScore()
    {
        score += 2;
        scoreText.text = "Score: " + score;
    }
    public void resetScore()
    {
        score = 0;
        UpdateScoreText();
    }
}
