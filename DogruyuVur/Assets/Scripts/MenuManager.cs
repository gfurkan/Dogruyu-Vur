using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject menuPanel;
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip buttonClick;
    [SerializeField]
    private GameObject volumeOnOffImage;

    bool volumeSettingsOn = true;
    void Start()
    {
        //Menu animations.
        menuPanel.GetComponent<RectTransform>().DOScale(1, 0.75f);
        menuPanel.GetComponent<CanvasGroup>().DOFade(1, 0.75f).SetEase(Ease.OutFlash);

        volumeSettingsOn = false;
        volumeOnOffImage.GetComponent<RectTransform>().localPosition = new Vector3(3, -222 - 0);
    }

    void Update()
    {
        
    }

    public void StartGame()
    {
        if (PlayerPrefs.GetInt("volume") == 1)
        {
            audioSource.PlayOneShot(buttonClick);
        }

        SceneManager.LoadScene("secondmenu");
    }
    public void Settings()
    {
        if (PlayerPrefs.GetInt("volume") == 1)
        {
            audioSource.PlayOneShot(buttonClick);
        }
        if (!volumeSettingsOn)
        {
            volumeOnOffImage.GetComponent<RectTransform>().DOLocalMoveY(-300,0.5f);
            volumeSettingsOn = true;
        }
        else
        {
            volumeOnOffImage.GetComponent<RectTransform>().DOLocalMoveY(-222, 0.5f);
            volumeSettingsOn = false;
        }
    }
    public void Quit()
    {

        if (PlayerPrefs.GetInt("volume") == 1)
        {
            audioSource.PlayOneShot(buttonClick);
        }
        Application.Quit();
    }
}
