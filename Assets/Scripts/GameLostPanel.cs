using System;
using TMPro;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLostPanel : MonoBehaviour
{
    [SerializeField] private Button replayButton;

    private void Awake()
    {
        replayButton.onClick.AddListener(() =>
        {
            GameManager.Instance.HandleGameReplay();
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
