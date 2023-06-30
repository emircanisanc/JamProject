using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class InGameUI : MonoBehaviour
{
    [SerializeField] GameObject winGameUI;
    [SerializeField] GameObject loseGameUI;

    void Awake()
    {
        GameManager.OnGameWin += ShowWinUI;
        GameManager.OnGameLose += ShowLoseUI;
    }

    void OnDisable()
    {
        GameManager.OnGameWin -= ShowWinUI;
        GameManager.OnGameLose -= ShowLoseUI;
    }
    
    private void ShowWinUI()
    {
        winGameUI.SetActive(true);
    }

    private void ShowLoseUI()
    {
        loseGameUI.SetActive(true);
    }

    public void LoadNextLevel()
    {
        int activeLevel = Int32.Parse(SceneManager.GetActiveScene().name.Split(" ")[1]);
        activeLevel = activeLevel + 1;
        SceneManager.LoadScene("Level "+ activeLevel);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
