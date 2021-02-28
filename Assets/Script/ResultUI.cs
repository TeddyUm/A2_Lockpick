using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultUI : MonoBehaviour
{
    public GameObject win;
    public GameObject lose;

    void Start()
    {
        if (GameManager.Instance.isWin)
        {
            win.SetActive(true);
            lose.SetActive(false); 
        }
        else
        {
            win.SetActive(false);
            lose.SetActive(true);
        }
    }

    public void RetryButton()
    {
        GameManager.Instance.ChangeScene("LevelSelect");
    }
    public void QuitButton()
    {
        Application.Quit();
    }
}
