using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static Action OnGameWin;
    public static Action OnGameLose;

    public float levelEndDuration = 2f;

    void Awake()
    {
        Door.OnDoorEntered += WinGame;
    }

    void OnDisable()
    {
        Door.OnDoorEntered -= WinGame;
    }

    private void WinGame()
    {
        OnGameWin?.Invoke();
    }

    private void LoseGame()
    {
        OnGameLose?.Invoke();
    }

}
