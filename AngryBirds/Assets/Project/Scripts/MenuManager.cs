using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject StartButton;
    
    //subscribe to event
    void Awake() {
        GameManager.OnGameStatechanged += GameManagerOnOnGameStateChanged;
    }

    //unsubscribe from event, good practice 
    void OnDestroy() {
        GameManager.OnGameStatechanged -= GameManagerOnOnGameStateChanged;
    }

    private void GameManagerOnOnGameStateChanged(GameState state) {
        StartButton.SetActive(state == GameState.StartScreen);
    }

    
}
