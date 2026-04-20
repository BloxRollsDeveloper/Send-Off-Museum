using UnityEngine;
using UnityEngine.UI;

public class SpriteScoreDisplay : MonoBehaviour
{
    [SerializeField] private Sprite[] digitSprites;
    [SerializeField] private Image tensDigit;  // Digit_0
    [SerializeField] private Image unitsDigit; // Digit_1

    public void UpdateDisplay(int score)
    {
        if (score < 10)
        {
            unitsDigit.gameObject.SetActive(false);
            tensDigit.gameObject.SetActive(true);
            tensDigit.sprite = digitSprites[score];
        }
        else
        {
            tensDigit.gameObject.SetActive(true);
            unitsDigit.gameObject.SetActive(true);
            tensDigit.sprite = digitSprites[score / 10];
            unitsDigit.sprite = digitSprites[score % 10];
        }
    }
}