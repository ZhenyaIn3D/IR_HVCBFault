using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class InfoPanelView : MonoBehaviour
{
    [SerializeField] private Button extraInfoButton;
    [SerializeField] private GameObject extraInfoPanel;
    [SerializeField] private VideoPlayer videoPlayer;
    
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
}
