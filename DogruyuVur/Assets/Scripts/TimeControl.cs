using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeControl : MonoBehaviour
{
    [SerializeField]
    private Text timeText;
    [SerializeField]
    private GameObject endGamePanel;

    int time = 90;
    bool decreaseTime = true;
    void Start()
    {
        StartCoroutine(TimeDecreaseControl());
    }

    IEnumerator TimeDecreaseControl()
    {
        while (decreaseTime) {
            yield return new WaitForSeconds(1);
            if (time < 10)
            {
                timeText.text = "0" + time.ToString();
            }
            else
            {
                timeText.text = time.ToString();
            }
            if (time <= 0)
            {
                decreaseTime = false;
                timeText.text = "00";
                endGamePanel.SetActive(true);

            }
            time--;
        }
    }
}
