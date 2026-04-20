using System;
using ModestTree;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class InfoPanelView : MonoBehaviour
{
    [SerializeField] private GameObject mainPanel;
    
    [SerializeField] private Button extraInfoButton;
    [SerializeField] private GameObject extraInfoPanel;
    [SerializeField] private VideoPlayer videoPlayer;

    [SerializeField] private GameObject videoInfo;
    [SerializeField] private Image[] imagesInfo;
    
    [SerializeField] private TextMeshProUGUI textInfo;
    
    private void OnEnable()
    {
        extraInfoButton.onClick.AddListener(ExtraButtonClicked);
    }

    private void OnDisable() {
        extraInfoButton.onClick.RemoveAllListeners();
    }

    private bool isExtraButtonClicked = false;
    public void ExtraButtonClicked()
    {
        if (isExtraButtonClicked) {
            isExtraButtonClicked = false;
            extraInfoButton.transform.rotation = Quaternion.Euler(0, 0, 0);
            extraInfoPanel.SetActive(false);
            videoPlayer.Stop();
        } else {
            isExtraButtonClicked = true;
            extraInfoButton.transform.rotation = Quaternion.Euler(0, 0, 45);
            extraInfoPanel.SetActive(true);
            videoPlayer.Play();
        }
    }

    public void ShowInfoPanel(bool isShow) {
        mainPanel.SetActive(isShow);
    }
    
    public void ShowExtraInfoPanel(bool isShow) {
        extraInfoPanel.SetActive(isShow);
        if (!isShow)
        {
            isExtraButtonClicked = false;
            extraInfoButton.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    public void ChnageInfoPanelContent(string text, VideoClip videoClip, Sprite[] sprites) {
        if (videoClip == null) {
            videoInfo.SetActive(false);
        }

        if (sprites.IsEmpty()) {
            foreach (var img in imagesInfo) {
                img.gameObject.SetActive(false);
            }
        }

        if (videoClip) {
            videoPlayer.clip = videoClip;
            videoInfo.SetActive(true);
        }

        if (sprites.Length > 0)
        {
            if (sprites[0] != null)
            {
                imagesInfo[0].sprite = sprites[0];
                imagesInfo[0].gameObject.SetActive(true);
            }

            if (sprites.Length > 1)
            {
                if (sprites[1] != null) {
                    imagesInfo[1].sprite = sprites[1];
                    imagesInfo[1].gameObject.SetActive(true);
                }
            }
            else {
                imagesInfo[1].gameObject.SetActive(false);
            }
            
        }

        if (videoClip == null && sprites.IsEmpty()) {
            extraInfoButton.gameObject.SetActive(false);  
            ShowExtraInfoPanel(false);
        } else {
            extraInfoButton.gameObject.SetActive(true);
        }
        
        textInfo.text = text;
    }
}
