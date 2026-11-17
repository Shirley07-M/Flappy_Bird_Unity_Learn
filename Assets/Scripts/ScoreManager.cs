using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Image[] imageDisplay;
    [SerializeField] private Sprite[] scoreSprite;
    public int currentScore {  get; private set; }

    [SerializeField] private BirdController birdController;
 
    private int scoreLength = 1;


    private void OnEnable()
    {
        birdController.OnPipePassed += UpdateScore;
    }
    private void OnDisable()
    {
        birdController.OnPipePassed -= UpdateScore;
    }
    public void UpdateScore()
    {
        currentScore++;
        DisplayScore(currentScore);
    }
    public void DisplayScore(int currentScore)
    {
        string score = currentScore.ToString();
        int scoreLength = score.Length;

        for(int i = scoreLength; i < imageDisplay.Length; i++)
        {
            imageDisplay[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < score.Length; i++)
        {
            imageDisplay[i].gameObject.SetActive(true);
            int num = score[i] - '0';
            imageDisplay[i].sprite = scoreSprite[num];
        }
    }

}
