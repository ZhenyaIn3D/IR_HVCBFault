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

    private void OnEnable()
    {
        mainMenuView.SetYesButton(YesCallback);
        mainMenuView.SetNoButton(NoCallback);
    }

    public void ShowStep(int index) {
        targetObserver.StartScanning(index);
        currentStep = index;
        mainMenuView.SetQuestionText(scriptDB.steps[currentStep].question);
        mainMenuView.ChangeStep(currentStep);
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
    
    // For buttons
    public void NextStep() {
        if (currentStep < 13) {
            currentStep++;    
        } else {
            mainMenuView.ShowEndScreen();
        }
        ShowStep(currentStep);
    }
    
    public void RestartApplication() {
        currentStep = 0;
        mainMenuView.HideEndScreen();
        mainMenuView.ShowWelcomePanel();
    }
 
} 
