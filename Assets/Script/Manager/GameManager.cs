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

    BirdEntity player;

    [Header("UI_Main")]
    [SerializeField] GameObject panel_Over;
    [SerializeField] Text txt_Score;
    [SerializeField] GameObject panel_Prop;

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
        player = Context.player.GetComponent<BirdEntity>();

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

    void Update()
    {
        if (player.isDead)
        {
            OnGameOver();
            return;
        }

        if (this.score != player.score)
        {
            this.score = player.score;
            SetScore();
        }
    }

    public void OnStartGame()
    {
        if (!isPause) { return; }

        player.Reset();
        panel_Prop.SetActive(true);

        isPause = false;
        Time.timeScale = 1;
    }

    public void OnGameOver()
    {
        if (isPause) { return; }

        panel_Prop.SetActive(false);

        txt_OverScore.text = "得分: <color=red>" + score.ToString() + "</color>";
        panel_Over.SetActive(true);

        isPause = true;
        Time.timeScale = 0;
    }

    public void SetScore()
    {
        txt_Score.text = "分数: " + score.ToString();
    }
}
