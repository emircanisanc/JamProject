using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

}
