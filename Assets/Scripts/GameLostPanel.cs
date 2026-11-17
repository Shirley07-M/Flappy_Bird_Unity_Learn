using System;
using TMPro;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLostPanel : MonoBehaviour
{
    [SerializeField] private Button replayButton;
    [SerializeField] private TextMeshProUGUI scoreText;

    private void Awake()
    {
        replayButton.onClick.AddListener(() =>
        {
            GameManager.Instance.HandleGameReplay();
        }
        );
    }

   
    public void ShowPanel(int score)
    {
        Debug.Log("Show panel thanh cong");
        gameObject.SetActive(true);
        scoreText.text = score.ToString();
    }
    public void HidePanel()
    {
        gameObject.SetActive(false);
    }
}
