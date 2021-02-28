using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectUI : MonoBehaviour
{
    public void EasyButton()
    {
        GameManager.Instance.difficulty = 0;
        GameManager.Instance.ChangeScene("MainGame");
    }
    public void NormalButton()
    {
        GameManager.Instance.difficulty = 1;
        GameManager.Instance.ChangeScene("MainGame");
    }

    public void HardButton()
    {
        GameManager.Instance.difficulty = 2;
        GameManager.Instance.ChangeScene("MainGame");
    }
}
