using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class SecondMenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject secondMenuPanel;
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip buttonClick;

    void Start()
    {
        secondMenuPanel.GetComponent<CanvasGroup>().DOFade(1,0.75f);
        secondMenuPanel.GetComponent<RectTransform>().DOScale(1, 0.75f).SetEase(Ease.OutFlash); 
    }
    public void ChooseGame(string levelNumber)
    {
        
        if (PlayerPrefs.GetInt("volume") == 1)
        {
            audioSource.PlayOneShot(buttonClick);
        }
        PlayerPrefs.SetString("levelnumber", levelNumber);
        SceneManager.LoadScene("gamescene");
    }
    public void BackToMenu()
    {
       
        if (PlayerPrefs.GetInt("volume") == 1)
        {
            audioSource.PlayOneShot(buttonClick);
        }
        SceneManager.LoadScene("menu");
    }
}
