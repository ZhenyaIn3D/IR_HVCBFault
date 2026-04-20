using System;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class StepController : MonoBehaviour {
    [Inject] ScanController targetObserver;
    [Inject] MainMenuView mainMenuView;
    
    public UnityEvent OnStepFirstStart;
    [SerializeField] private DataBaseSO scriptDB;
    
    private int currentStep = 0;
    
    private void OnEnable() {
        mainMenuView.SetContinueButton(NextStep);
        
        scriptDB.steps[0].OnYesClicked += StepZeroClickedYes;
        scriptDB.steps[0].OnNoClicked += NextStep;
    }

    public void ShowStep(int index) {
        mainMenuView.SetYesButton(scriptDB.steps[index].OnYesClicked);
        mainMenuView.SetNoButton(scriptDB.steps[index].OnNoClicked);
        targetObserver.StartScanning(index);
        currentStep = index;
        mainMenuView.ChangeStep(currentStep, scriptDB.steps[index].stepName, scriptDB.steps[index].infoPanelText);
        mainMenuView.ChangeUserInputType(scriptDB.steps[currentStep].userInputType);
        mainMenuView.ChangeInfoPanelViewContent(scriptDB.steps[currentStep].infoPanelText, scriptDB.steps[currentStep].infoVideoClip, scriptDB.steps[currentStep].infoSprites);
    }
    
    public void YesCallback() {
        // end screen
        mainMenuView.ShowEndScreen();
    }

    public void NoCallback() {
        NextStep();
    }

    public void StartSteps() {
        currentStep = 0;
        mainMenuView.HideWelcomePanel();
        ShowStep(currentStep);
    }

    public void SelectStep(int index) {
        currentStep = index - 1;
        mainMenuView.ResetButtons();
        
        NextStep();
    }
    
    // For buttons
    public void NextStep() {
        if (currentStep < 12) {
            currentStep++;    
        } else {
            mainMenuView.ShowEndScreen();
        }
        ShowStep(currentStep);
    }
    
    public void RestartApplication() {
        currentStep = 0;
        mainMenuView.HideEndScreen();
        mainMenuView.ResetButtons();
        mainMenuView.ChangeStep(currentStep, scriptDB.steps[currentStep].stepName, scriptDB.steps[currentStep].infoPanelText);
        mainMenuView.ChangeUserInputType(scriptDB.steps[currentStep].userInputType);
        mainMenuView.ChangeInfoPanelViewContent(scriptDB.steps[currentStep].infoPanelText, scriptDB.steps[currentStep].infoVideoClip, scriptDB.steps[currentStep].infoSprites);
        mainMenuView.ShowWelcomePanel();
    }

    private void StepZeroClickedYes() {
        currentStep = 5;
        NextStep();
    }
    
 
} 
