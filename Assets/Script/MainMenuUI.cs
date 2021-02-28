using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    public void StartGame()
    {
        GameManager.Instance.ChangeScene("LevelSelect");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
