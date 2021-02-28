using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockPickSystem : MonoBehaviour
{
    [SerializeField]
    bool isHorizontal;

    public int speed;
    public float rotationVal;

    private bool horizotalAnsEnt;
    private bool verticalAnsEnt;
    void Start()
    {
        switch(GameManager.Instance.difficulty)
        {
            case 0:
                GameManager.Instance.time = 120.0f;
                GameManager.Instance.answerArea = 10.0f;
                break;
            case 1:
                GameManager.Instance.time = 60.0f;
                GameManager.Instance.answerArea = 5.0f;
                break;
            case 2:
                GameManager.Instance.time = 30.0f;
                GameManager.Instance.answerArea = 2.0f;
                break;
            default:
                GameManager.Instance.time = 120.0f;
                GameManager.Instance.answerArea = 10.0f;
                break;
        }
        GameManager.Instance.horizontalAns = Random.Range(-10, -80);
        GameManager.Instance.verticalAns = Random.Range(-10, -80);
    }

    // Update is called once per frame
    void Update()
    {
        if(isHorizontal)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, rotationVal, 0);

            if (Input.GetKey(KeyCode.A) && rotationVal < 0)
            {
                rotationVal += Time.deltaTime * speed;
            }
            if (Input.GetKey(KeyCode.D) && rotationVal > -90)
            {
                rotationVal -= Time.deltaTime * speed;
            }

            if(rotationVal > GameManager.Instance.horizontalAns - 2 && rotationVal < GameManager.Instance.horizontalAns + 2)
            {
                if(!horizotalAnsEnt)
                {
                    horizotalAnsEnt = true;
                    Debug.Log("horizontal ans");
                }
            }
            else
            {
                horizotalAnsEnt = false;
            }
        }
        else
        {
            float wheel = Input.GetAxis("Mouse ScrollWheel") * speed;
            gameObject.transform.rotation = Quaternion.Euler(rotationVal, 0, 0);

            if (wheel > 0 && rotationVal < 0)
            {
                rotationVal += Time.deltaTime * speed;
            }
            if (wheel < 0 && rotationVal > -90)
            {
                rotationVal -= Time.deltaTime * speed;
            }

            if (rotationVal > GameManager.Instance.verticalAns - 2 && rotationVal < GameManager.Instance.verticalAns + 2)
            {
                if (!verticalAnsEnt)
                {
                    verticalAnsEnt = true;
                    Debug.Log("vertical ans");
                }
            }
            else
            {
                verticalAnsEnt = false;
            }
        }
    }

    public void AnsClick()
    {

    }
}
