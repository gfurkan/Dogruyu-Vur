using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class RingRotationControl : MonoBehaviour
{
    string resultValue;
    GameManager gameManager;

    private void Awake()
    {
        gameManager = Object.FindObjectOfType<GameManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ball")
        {
            gameObject.transform.DORotate(transform.eulerAngles + Quaternion.AngleAxis(45, Vector3.forward).eulerAngles,0.5f);
        }
        if (gameObject.name == "LeftRing")
        {
            resultValue = GameObject.Find("LeftCircleText").GetComponent<Text>().text;
        }
        if (gameObject.name == "MiddleRing")
        {
            resultValue = GameObject.Find("MiddleCircleText").GetComponent<Text>().text;
        }
        if (gameObject.name == "RightRing")
        {
            resultValue = GameObject.Find("RightCircleText").GetComponent<Text>().text;
        }
        gameManager.CheckResult(int.Parse(resultValue));
    }
}
