using System;
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

    public void ChnageInfoPanelContent(string text, VideoClip videoClip, Image image = null) {
        videoPlayer.clip = videoClip;
        textInfo.text = text;
    }
}
