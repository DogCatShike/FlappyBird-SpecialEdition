using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    int score;

    [Header("UI")]
    public GameObject panel_Over;
    public Text txt_Score;

    void Awake()
    {
        instance = this;

        score = 0;
    }

    public void AddScore(int amount)
    {
        score += amount;
        txt_Score.text = "分数: " + score.ToString();
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        panel_Over.SetActive(true);
    }

    public void ResetGame()
    {
        score = 0;
        txt_Score.text = "分数: " + score.ToString();
    }
}