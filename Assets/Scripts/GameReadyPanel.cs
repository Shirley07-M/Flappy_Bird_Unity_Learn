using System;
using TMPro;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameReadyPanel : MonoBehaviour
{
    [SerializeField] private Button playButton;

    private void Awake()
    {
        playButton.onClick.AddListener(() =>
        {
            GameManager.Instance.ChangeGameState(GameManager.GameState.Playing);
            HidePanel();
        }
        );
    }


    public void ShowPanel()
    {
        Debug.Log("Show panel thanh cong");
        gameObject.SetActive(true);

    }
    public void HidePanel()
    {
        gameObject.SetActive(false);
    }
}
