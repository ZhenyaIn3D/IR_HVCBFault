using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MainMenuView : MonoBehaviour
{
    public Button YesButton;
    public Button NoButton;

    public TextMeshProUGUI questionText;

    [SerializeField] private GameObject stepsPanel;
    public GameObject informationPanel;


    [SerializeField] private GameObject MuteImage;
    public AudioSource audioSource;
    public void ChangeMute() {
        if (audioSource.mute) {
            audioSource.mute = false;
            MuteImage.SetActive(false);
        } else {
            audioSource.mute = true;
            MuteImage.SetActive(true);
        }
    }

    public void SetYesButton(UnityAction callback) {
        YesButton.onClick.RemoveAllListeners();
        YesButton.onClick.AddListener(callback);
    }

    public void SetNoButton(UnityAction callback) {
        NoButton.onClick.RemoveAllListeners();
        NoButton.onClick.AddListener(callback);
    }
    
    public void SetQuestionText(string text) {
        questionText.text = text;
    }

    public void ChangeVisabilityStepsPanel() {
        stepsPanel.SetActive(!stepsPanel.activeSelf);
    }
}
