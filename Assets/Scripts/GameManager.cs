using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    [SerializeField] private BirdController birdController;
    [SerializeField] private GameLostPanel gameLostPanel;
    [SerializeField] private GameReadyPanel gameReadyPanel;
    [SerializeField] private ScoreManager scoreManager;
    private static bool onGameFlow = false;
    public enum GameState
    {
        Ready,
        Playing,
        GameOver
    }
    private GameState currentState;


    private void Awake()
    {
        Instance = this;
       
    }

    private void Start()
    {
        if (!onGameFlow) HandleGameStart();
        else onGameFlow = false;
    }

    private void OnEnable()
    {
        birdController.OnGameOver += HandleGameOver;
    }
    private void OnDisable()
    {
        birdController.OnGameOver -= HandleGameOver;
    }
    

    public void ChangeGameState(GameState newState)
    {
        currentState = newState;

        if(currentState is GameState.Ready)
        {
            birdController.interactable = false;
            Time.timeScale = 0f;
        }
        else if (currentState is GameState.Playing)
        {
            scoreManager.DisplayScore(0);
            birdController.interactable = true;
            Time.timeScale = 1f; 
        }
        else if (currentState is GameState.GameOver)
        {
            birdController.interactable = false;
            Time.timeScale = 0f; 
        }
    }
    private void HandleGameOver()
    {
        ChangeGameState(GameState.GameOver);
        scoreManager.gameObject.SetActive(false);
        gameLostPanel.ShowPanel(scoreManager.currentScore);  
    }
    private void HandleGameStart()
    {
        ChangeGameState(GameState.Ready);
        scoreManager.gameObject.SetActive(true);
        gameReadyPanel.ShowPanel();
    }
    public void HandleGameReplay()
    {
        onGameFlow = true;
        SceneManager.LoadScene(0);
        ChangeGameState(GameState.Playing);
        gameLostPanel.HidePanel();
    }
}
