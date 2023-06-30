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
        PlayerManager.OnPlayerDie += LoseGame;
        Time.timeScale = 1f;
    }

    void OnDisable()
    {
        Door.OnDoorEntered -= WinGame;
        PlayerManager.OnPlayerDie -= LoseGame;
    }

    public void WinGame()
    {
        OnGameWin?.Invoke();
        Time.timeScale = 0f;
    }

    public void LoseGame()
    {
        OnGameLose?.Invoke();
        Time.timeScale = 0f;
    }

}
