using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private SpriteScoreDisplay spriteDisplay;
    private int scoreCount = 0;

    void Start()
    {
        UpdateScoreText();
    }

    public void AddScore()
    {
        scoreCount++;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if (spriteDisplay != null)
            spriteDisplay.UpdateDisplay(scoreCount);
    }
}