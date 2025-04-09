using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    int score;

    [Header("UI")]
    [SerializeField] GameObject panel_Over;
    Text txt_OverScore;
    [SerializeField] Text txt_Score;

    void Awake()
    {
        instance = this;

        score = 0;

        txt_OverScore = panel_Over.transform.Find("Txt_OverScore").GetComponent<Text>();
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
        txt_OverScore.text = "得分: <color=red>" + score.ToString() + "</color>";
    }

    public void ResetGame()
    {
        score = 0;
        txt_Score.text = "分数: " + score.ToString();
    }
}