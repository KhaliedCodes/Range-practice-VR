
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Reference to a UI Text element to display score
    private int score = 0;

    void Start()
    {
        UpdateScoreText();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball")) // Ensure the ball has the tag "Ball"
        {
            score++;
            UpdateScoreText();
            Debug.Log("Score: " + score);
        }
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    public void resetScore()
    {
        score = 0;
        UpdateScoreText();
    }
}
