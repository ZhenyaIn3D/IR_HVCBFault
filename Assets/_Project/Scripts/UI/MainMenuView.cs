using System;
using _Project.Scripts.UI;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MainMenuView : MonoBehaviour
{
    [SerializeField] private string[] stepsName;
    [SerializeField] private StepCell[]  stepCells;
    
    public Button YesButton;
    public Button NoButton;

    public TextMeshProUGUI questionText;

    [SerializeField] private GameObject stepsPanel;
    public GameObject informationPanel;
    
    [SerializeField] private GameObject MuteImage;

    [SerializeField] private TextMeshProUGUI stepText;
    [SerializeField] private TextMeshProUGUI nameStepText;
    
    [SerializeField] private GameObject EndScreen;
    [SerializeField] private GameObject WelcomePanel;
    
    public Color defaultStepCellColor;
    public Color setStepCellColor;
    public Color FutureStepCellColor;
    
    public AudioSource audioSource;

    private void OnEnable() {
        for (var index = 0; index < stepCells.Length; index++) {
            var showIndex = index + 1;
            var stepCell = stepCells[index];
            stepCell.stepNumberText.text = (showIndex >= 10 ? "" : "0") + showIndex;
            stepCell.stepText.text = stepsName[index];
            stepCell.stepNumberText.color = FutureStepCellColor;
        }
        
        stepCells[0].stepNumberText.color = setStepCellColor;
    }

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

        if (text == "") {
            NoButton.gameObject.SetActive(false);
            YesButton.gameObject.SetActive(false);
        } else {
            NoButton.gameObject.SetActive(true);
            YesButton.gameObject.SetActive(true);
        }
    }

    public void ChangeVisabilityStepsPanel() {
        stepsPanel.SetActive(!stepsPanel.activeSelf);
    }

    public void ChangeStep(int index)
    {
        var showIndex = index + 1;
        stepText.text = (showIndex >= 10 ? "" : "0") + showIndex.ToString();
        
        
        string ltrMark = "\u200E"; 

        // Форматируем номер: если меньше 10, добавляем 0 спереди (01, 02...)
        string formattedIndex = (index < 10 ? "0" : "") + index;

        // Собираем строку с маркерами
        nameStepText.text = $"{stepsName[index]}";
        
        for (var i = 0; i < index; i++) {
            var stepCell = stepCells[i];
            stepCell.stepNumberText.color = defaultStepCellColor;
        }

        stepCells[index].stepNumberText.color = setStepCellColor;
    }
    
    public void ShowEndScreen() {
        EndScreen.SetActive(true);
    }

    public void HideEndScreen() {
        EndScreen.SetActive(false);
    }
    
    public void QuitApplication() {
        Application.Quit();
    }
    
    public void ShowWelcomePanel() {
        WelcomePanel.SetActive(true);
    }

    public void HideWelcomePanel() {
        WelcomePanel.SetActive(false);
    }
}
