using TMPro;
using UnityEngine;

namespace _Project.Scripts.UI
{
    public enum StepStatus
    {
        pass,
        now,
        wiil
    }
    
    public class StepCell : MonoBehaviour
    {
        public TextMeshProUGUI stepNumberText;
        public TextMeshProUGUI stepText;
        
        public void SetStepStatus(StepStatus stepStatus)
        {
            
        }
    }
}