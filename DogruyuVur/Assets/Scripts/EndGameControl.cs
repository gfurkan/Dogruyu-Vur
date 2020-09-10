using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class EndGameControl : MonoBehaviour
{
    [SerializeField]
    private Image endGameImage;
    [SerializeField]
    private Text trueNumberText;
    [SerializeField]
    private Text falseNumberText;
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Button playAgainButton;
    [SerializeField]
    private Button chooseLevelButton;
    [SerializeField]
    private Button backtoMenuButton;
    [SerializeField]
    private GameObject[] closeattheEnd;
    [SerializeField]
    private AudioClip buttonClick;
    [SerializeField]
    private AudioSource audioSource;
    GameManager gameManager;

    float imageOpeningTime = 0;
    bool imageOpened = false;
    private void Awake()
    {
        gameManager = Object.FindObjectOfType<GameManager>();
        playAgainButton.GetComponent<RectTransform>().localScale = Vector3.zero;
        chooseLevelButton.GetComponent<RectTransform>().localScale = Vector3.zero;
        backtoMenuButton.GetComponent<RectTransform>().localScale = Vector3.zero;
        StartCoroutine(OpenImage());
        
    }

   IEnumerator OpenImage()
    {
        while (!imageOpened)
        {
            trueNumberText.text = (gameManager.trueNumber.ToString() + " DOĞRU");
            falseNumberText.text = (gameManager.falseNumber.ToString() + " YANLIŞ");
            scoreText.text = (gameManager.score.ToString() + " PUAN");

            foreach (var gameObject in closeattheEnd)
            {
                gameObject.SetActive(false);
            }

            imageOpeningTime += 0.15f;
            endGameImage.fillAmount = imageOpeningTime;
            yield return new WaitForSeconds(0.1f);
            if (imageOpeningTime >= 1)
            {
                imageOpeningTime = 1;
                trueNumberText.GetComponent<CanvasGroup>().DOFade(1, 0.3f);
                yield return new WaitForSeconds(0.5f);
                falseNumberText.GetComponent<CanvasGroup>().DOFade(1, 0.3f);
                yield return new WaitForSeconds(0.5f);
                scoreText.GetComponent<CanvasGroup>().DOFade(1, 0.3f);
                yield return new WaitForSeconds(0.75f);
                playAgainButton.GetComponent<RectTransform>().DOScale(1, 0.5f);
                chooseLevelButton.GetComponent<RectTransform>().DOScale(1, 0.5f);
                backtoMenuButton.GetComponent<RectTransform>().DOScale(1, 0.5f);
                imageOpened = true;
            }
        }
    }
    public void PlayAgain()
    {
        if (PlayerPrefs.GetInt("volume") == 1)
        {
            audioSource.PlayOneShot(buttonClick);
        }
        SceneManager.LoadScene("gamescene");
    }
    public void ChooseLevel()
    {
        if (PlayerPrefs.GetInt("volume") == 1)
        {
            audioSource.PlayOneShot(buttonClick);
        }
        SceneManager.LoadScene("secondmenu");
    }
    public void BacktoMenu()
    {
        if (PlayerPrefs.GetInt("volume") == 1)
        {
            audioSource.PlayOneShot(buttonClick);
        }
        SceneManager.LoadScene("menu");
    }
}
