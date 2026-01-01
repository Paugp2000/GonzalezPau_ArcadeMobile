using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public enum GameState { Menu, Game, LevelComplete, Gameover}

    private GameState gameState;

    public static Action<GameState> OnGameStateChanged; 

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setGamestate(GameState gameState)
    {
        this.gameState = gameState;
        OnGameStateChanged?.Invoke(gameState);
        Debug.Log ("El estado del juego es " + gameState);   
    }

    public bool IsGameState()
    {
        return gameState == GameState.Game;
    }
}
