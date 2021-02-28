using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainGameUI : MonoBehaviour
{
    public LockPickSystem horizontalLock;
    public LockPickSystem verticalLock;
    public Image blinkImage;
    public Text distViewer;
    public Text timeText;

    public Button skillSpeed;
    public Button skillSense;
    public Text incorrectText;

    private float totalDist;
    private float timer;

    private float skillCoolTime;
    private float skillTimer;
    private bool canSkill;

    void Start()
    {
        skillCoolTime = 2.0f;
        canSkill = true;
    }
    void Update()
    {
        GameManager.Instance.time -= Time.deltaTime;
        timeText.text = "" + (int)GameManager.Instance.time;
        totalDist = Mathf.Abs(Mathf.Abs(GameManager.Instance.horizontalAns) - Mathf.Abs(horizontalLock.rotationVal)) +
            Mathf.Abs(Mathf.Abs(GameManager.Instance.verticalAns) - Mathf.Abs(verticalLock.rotationVal));
        timer += Time.deltaTime * 20;

        if (timer > totalDist)
        {
            timer = 0;
            if(totalDist < GameManager.Instance.answerArea)
            {
                blinkImage.enabled = true;
            }
            else
            {
                StartCoroutine("Blink");
            }
        }

        if(canSkill)
        {
            skillSpeed.interactable = true;
            skillSense.interactable = true;
            skillTimer = 0;
        }
        else
        {
            skillTimer += Time.deltaTime;
            skillSpeed.interactable = false;
            skillSense.interactable = false;

            if(skillTimer > 2.0f)
            {
                canSkill = true;
            }
        }

        if(GameManager.Instance.time < 0)
        {
            GameManager.Instance.isWin = false;
            GameManager.Instance.ChangeScene("Result");
        }
    }

    public void SkillSense()
    {
        canSkill = false;
        StartCoroutine("SkillDistView");
    }

    public void SkillSpeed()
    {
        canSkill = false;
        StartCoroutine("SkillSpeedUp");
    }
    public void Unlock()
    {
        if(GameManager.Instance.answerArea > totalDist)
        {
            GameManager.Instance.isWin = true;
            GameManager.Instance.ChangeScene("Result");
        }
        else
        {
            incorrectText.enabled = true;
            Invoke("IncorrectEnd", 1.0f);
            GameManager.Instance.time -= 5.0f;
        }
    }

    public void IncorrectEnd()
    {
        incorrectText.enabled = false;
    }

    IEnumerator Blink()
    {
        blinkImage.enabled = true;
        yield return new WaitForSeconds(0.2f);
        blinkImage.enabled = false;
    }

    IEnumerator SkillDistView()
    {
        distViewer.enabled = true;
        distViewer.text = "Distance: " + (int)totalDist;
        yield return new WaitForSeconds(1.0f);
        distViewer.enabled = false;
    }
    IEnumerator SkillSpeedUp()
    {
        horizontalLock.speed *= 2;
        verticalLock.speed *= 2;
        yield return new WaitForSeconds(1.0f);
        horizontalLock.speed /= 2;
        verticalLock.speed /= 2;
        distViewer.enabled = false;
    }
}
