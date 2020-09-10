using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject startWord;
    [SerializeField]
    private Text questionText;
    [SerializeField]
    private Text firstResultText;
    [SerializeField]
    private Text secondResultText;
    [SerializeField]
    private Text thirdResultText;
    [SerializeField]
    private Text trueNumberText;
    [SerializeField]
    private Text falseNumberText;
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Image trueImage;
    [SerializeField]
    private Image falseImage;

    string levelno;

    int firstNumber = 0;
    int secondNumber = 0;
    int result = 0;
    int firstFalseResult = 0;
    int secondFalseResult = 0;
    public int trueNumber = 0;
    public int falseNumber = 0;
    public int score = 0;

    CannonControl cannonControl;
    AdMobManager adMobManager;
    private void Awake()
    {
        cannonControl = Object.FindObjectOfType<CannonControl>();
        adMobManager = Object.FindObjectOfType<AdMobManager>();
    }
    void Start()
    {

        StartCoroutine(StartWordControl());

        if (PlayerPrefs.HasKey("levelnumber"))
        {
            levelno=(PlayerPrefs.GetString("levelnumber"));
            
        }
       
    }

    IEnumerator StartWordControl()
    {
        startWord.GetComponent<RectTransform>().DOScale(1.3f, 0.5f);
        yield return new WaitForSeconds(0.6f);
        startWord.GetComponent<RectTransform>().DOScale(0, 0.5f).SetEase(Ease.InBack);
        startWord.GetComponent<CanvasGroup>().DOFade(0, 1);
        yield return new WaitForSeconds(0.6f);
        StartGame();
    }

    void StartGame()
    {
        cannonControl.changeRotation = true;
        PrepareQuestion();
        adMobManager.ShowBanner();
    }
    void FirstNumber()
    {
        switch(levelno)
        {
            case "two":
                firstNumber = 2;
                break;
            case "three":
                firstNumber = 3;
                break;
            case "four":
                firstNumber = 4;
                break;
            case "five":
                firstNumber = 5;
                break;
            case "six":
                firstNumber = 6;
                break;
            case "seven":
                firstNumber = 7;
                break;
            case "eight":
                firstNumber = 8;
                break;
            case "nine":
                firstNumber = 9;
                break;
            case "ten":
                firstNumber = 10;
                break;
            case "mixed":
                firstNumber = Random.Range(2,11);
                break;
        }
    }
    void PrepareQuestion()
    {
        FirstNumber();
        int randomValue = Random.Range(1,100);
        secondNumber = Random.Range(1, 11);
        if (randomValue <= 50)
        {
            questionText.text = firstNumber.ToString() + "x" + secondNumber.ToString();
        }
        else
        {
            questionText.text = secondNumber.ToString() + "x" + firstNumber.ToString();
        }
        result = firstNumber * secondNumber;
        Result();
    }
    void Result()
    {
        firstFalseResult = result + Random.Range(2, 10);

        if (result > 10)
        {
            secondFalseResult = result - Random.Range(2, 8);
        }
        else
        {
            secondFalseResult = Mathf.Abs(result - Random.Range(1, 5));
        }

        int randomValue = Random.Range(1, 100);
        if (randomValue <= 33)
        {
            firstResultText.text = result.ToString();
            secondResultText.text = firstFalseResult.ToString();
            thirdResultText.text = secondFalseResult.ToString();
        }
        if (randomValue > 33 && randomValue <= 66)
        {
            firstResultText.text = firstFalseResult.ToString();
            secondResultText.text = result.ToString();
            thirdResultText.text = secondFalseResult.ToString();
        }
        if (randomValue > 66 && randomValue <= 99)
        {
            firstResultText.text = firstFalseResult.ToString();
            thirdResultText.text = result.ToString();
            secondResultText.text = secondFalseResult.ToString();
        }
    }
    public void CheckResult(int circleValue)
    {
        if (circleValue == result)
        {
            trueNumber++;
            score += 20;
            StartCoroutine(TrueImageControl());
            PrepareQuestion();
        }
        else
        {
            falseNumber++;
            score -= 10;
            StartCoroutine(FalseImageControl());
        }
        trueNumberText.text = trueNumber.ToString() + " DOĞRU";
        falseNumberText.text = falseNumber.ToString() + " YANLIŞ";
        scoreText.text = score.ToString() + " PUAN";
    }
    IEnumerator TrueImageControl()
    {
        trueImage.GetComponent<RectTransform>().DOScale(1, 0.2f);
        trueImage.GetComponent<CanvasGroup>().DOFade(1, 0.2f);
        yield return new WaitForSeconds(0.5f);
        trueImage.GetComponent<RectTransform>().DOScale(0, 0.2f);
        trueImage.GetComponent<CanvasGroup>().DOFade(0, 0.2f);
    }
    IEnumerator FalseImageControl()
    {
        falseImage.GetComponent<RectTransform>().DOScale(1, 0.2f);
        falseImage.GetComponent<CanvasGroup>().DOFade(1, 0.2f);
        yield return new WaitForSeconds(0.5f);
        falseImage.GetComponent<RectTransform>().DOScale(0, 0.2f);
        falseImage.GetComponent<CanvasGroup>().DOFade(0, 0.2f);
    }
}
