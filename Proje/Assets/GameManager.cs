using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static Action OnGameEnd;

    public float levelEndDuration = 2f;

    void Awake()
    {
        Door.OnDoorEntered += EndGame;
    }

    void OnDisable()
    {
        Door.OnDoorEntered -= EndGame;
    }
    
    private void EndGame()
    {
        OnGameEnd?.Invoke();
    }

}
