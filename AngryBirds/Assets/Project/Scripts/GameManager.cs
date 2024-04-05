using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public GameState State;

    public static event Action<GameState> OnGameStateChanged;

    //singleton
    private void Awake() 
    {
        if(instance == null)
        {
            instance = this;
        }
        else 
        {
            Destroy(gameObject);
        }
    }
    
    void Start()
    {
        UpdateGameState(GameState.StartScreen);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateGameState(GameState newState) {
        State = newState;

        switch (newState) {
            case GameState.StartScreen:
                break;
            case GameState.GameLoop:
                break;
            case GameState.LoseScreen:
                break;
            case GameState.OneStarScreen:
                break;
            case GameState.TwoStarScreen:
                break;
            case GameState.ThreeStarScreen:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);        
        }

        OnGameStateChanged?.Invoke(newState);
    }

    public enum GameState {
        StartScreen,
        GameLoop,
        LoseScreen,
        OneStarScreen,
        TwoStarScreen,
        ThreeStarScreen
    }
}
