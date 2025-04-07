using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static bool isPause;

    int score;

    [Header("UI_Main")]
    [SerializeField] GameObject panel_Over;
    [SerializeField] Text txt_Score;

    [Header("UI_Element")]
    [SerializeField] Button btn_Restart;
    [SerializeField] Button btn_Back;
    [SerializeField] Text txt_OverScore;

    void Awake()
    {
        instance = this;
        isPause = false;

        score = 0;
    }

    void Start()
    {
        btn_Restart.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            OnStartGame();
        });

        btn_Back.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(0);
            OnStartGame();
        });
    }

    public void OnStartGame()
    {
        if (!isPause) { return; }

        isPause = false;
        Time.timeScale = 1;
    }

    public void OnGameOver()
    {
        if (isPause) { return; }
        Debug.Log("OnGameOver");

        txt_OverScore.text = "得分: <color=red>" + score.ToString() + "</color>";
        panel_Over.SetActive(true);

        isPause = true;
        Time.timeScale = 0;
    }

    public void AddScore(int addScore)
    {
        score += addScore;
        txt_Score.text = "分数: " + score.ToString();
    }
}
