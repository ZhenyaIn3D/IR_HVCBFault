using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum UserInputType
{
    YesNo,
    Continue
}

public class UserInputView : MonoBehaviour
{
    [SerializeField] private Button yesBtn;
    [SerializeField] private Button noBtn;
    [SerializeField] private Button continueBtn;
    
    [SerializeField] private TextMeshProUGUI textInfo;
    
    public void SwitchUserInput(UserInputType type)
    {
        switch (type)
        {
            case UserInputType.YesNo:
                yesBtn.gameObject.SetActive(true);
                noBtn.gameObject.SetActive(true);
                break;
            case UserInputType.Continue:
                yesBtn.gameObject.SetActive(false);
                noBtn.gameObject.SetActive(false);
                continueBtn.gameObject.SetActive(true);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }
    }
}
