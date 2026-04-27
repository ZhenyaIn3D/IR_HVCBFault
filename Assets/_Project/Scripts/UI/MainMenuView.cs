using System;
using _Project.Scripts.UI;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.Video;

public class MainMenuView : MonoBehaviour
{
    // [SerializeField] private string[] stepsName;
    [SerializeField] private StepCell[]  stepCells;
    
    public Button YesButton;
    public Button NoButton;
    public Button ContinueButton;

    public TextMeshProUGUI questionText;

    [SerializeField] private GameObject stepsPanel;
    public GameObject informationPanel;
    
    [SerializeField] private UserInputView userInputView;

    [SerializeField] private GameObject aboutAppPanel;
    [SerializeField] private  InfoPanelView infoPanelView;
    
    [SerializeField] private GameObject MuteImage;

    [SerializeField] private TextMeshProUGUI stepText;
    [SerializeField] private TextMeshProUGUI nameStepText;
    
    [SerializeField] private GameObject EndScreen;
    [SerializeField] private GameObject WelcomePanel;
    [SerializeField] private GameObject FirstStepImage;
    
    public Color defaultStepCellColor;
    public Color setStepCellColor;
    public Color FutureStepCellColor;
    
    public AudioSource audioSource;
    
    [SerializeField] private DataBaseSO scriptDB;

    private void OnEnable()
    {
        ResetButtons();
    }

    public void ResetButtons() {
        for (var index = 0; index < scriptDB.steps.Count; index++) {
            var showIndex = index + 1;
            var stepCell = stepCells[index];
            stepCell.stepNumberText.text = (showIndex >= 10 ? "" : "0") + showIndex;
            stepCell.stepText.text = scriptDB.steps[index].stepName;
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

    public void SetContinueButton(UnityAction callback) {
        ContinueButton.onClick.RemoveAllListeners();
        ContinueButton.onClick.AddListener(callback);
    }

    public void ChangeUserInputType(UserInputType userInputType) {
        userInputView.SwitchUserInput(userInputType);
    }
    
    public void ChangeVisabilityStepsPanel() {
        stepsPanel.SetActive(!stepsPanel.activeSelf);
    }

    public void ChangeStep(int index, string stepName, string stepInfo)
    {
        var showIndex = index + 1;
        stepText.text = (showIndex >= 10 ? "" : "0") + showIndex.ToString();

        if (index == 0) {
            FirstStepImage.SetActive(true);
        } else {
            FirstStepImage.SetActive(false);
        }
        
        string ltrMark = "\u200E"; 

        // Форматируем номер: если меньше 10, добавляем 0 спереди (01, 02...)
        string formattedIndex = (showIndex < 10 ? "0" : "") + showIndex;

        // Собираем строку с маркерами
        string reversedIndex = formattedIndex[1].ToString() + formattedIndex[0].ToString();
        nameStepText.text = $"{stepName} | {reversedIndex}";
        
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
        aboutAppPanel.SetActive(true);
        infoPanelView.ShowExtraInfoPanel(false);
    }

    public void HideWelcomePanel() {
        WelcomePanel.SetActive(false);
        
    }

    public void ChangeInfoPanelViewContent(string text, VideoClip videoClip, Sprite[] image) {
        infoPanelView.ChnageInfoPanelContent(text, videoClip, image);
    }
}
