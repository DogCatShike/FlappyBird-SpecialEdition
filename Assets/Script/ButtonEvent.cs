using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonEvent : MonoBehaviour
{
    [SerializeField] Button btn_Restart;
    [SerializeField] Button btn_Back;

    void Awake()
    {
        if (btn_Restart != null)
        {
            btn_Restart.onClick.AddListener(() =>
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                Time.timeScale = 1;
            });
        }

        if (btn_Back != null)
        {
            btn_Back.onClick.AddListener(() =>
            {
                SceneManager.LoadScene(0);
                Time.timeScale = 1;
            });
        }
    }

    public void OnStartClick()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void OnQuitClick()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }
}