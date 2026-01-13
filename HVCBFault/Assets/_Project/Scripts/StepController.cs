using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class StepController : MonoBehaviour {
    [Inject] ScanController targetObserver;
    [Inject] MainMenuView mainMenuView;
    
    public UnityEvent OnStepFirstStart;
    [SerializeField] private DataBaseSO scriptDB;
    
    private int currentStep = 1;

#region Step 1

    // step 1
    public void StartScanning() {
        currentStep = 1;
        OnStepFirstStart?.Invoke();
        targetObserver.StartScanning();
        targetObserver.OnScanFound += OnScanFound;
    }

    public void OnScanFound() {
        Debug.Log("OnScanFound");
        ShowSecondStep();
    }

#endregion
 

#region Step 2

    //step 2
    public void ShowSecondStep() {
        currentStep = 2;
        mainMenuView.SetYesButton(YesCallback);
        mainMenuView.SetNoButton(NoCallback);
        mainMenuView.SetQuestionText(scriptDB.steps[currentStep].question);
    }

    public void YesCallback() {
        Debug.Log("Press YES");
    }

    public void NoCallback() {
        Debug.Log("Press NO");
    }

#endregion
    
    
    
    // For buttons
    public void NextStep() {
        if (currentStep == 1) {
            ShowSecondStep();
        } else if (currentStep == 2) {
            
        }
    }
} 
