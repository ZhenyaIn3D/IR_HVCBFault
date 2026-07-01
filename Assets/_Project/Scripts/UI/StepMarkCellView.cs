using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Project.Scripts.UI {
    public class StepMarkCellView : MonoBehaviour {
        [Inject] private StepController StepController;
        
        [SerializeField] private Image markImage;
        [SerializeField] private Image checkMArkImage;
        
        [SerializeField] private Sprite finishSprite;
        [SerializeField] private Sprite notFinishSprite;

        [SerializeField] private int stepCount;

        private void OnEnable() {
            var isExist = StepController.stepDoneDictionary.TryGetValue(stepCount, out bool value);
            if (isExist)
                SetMarkFinished(value);
            else {
                SetMarkFinished(false);
            }
        }

        public void SetMarkFinished(bool isFinished) {
            if (isFinished)
            {
                markImage.color = new Color(0.1f, 0.75f, 0.61f);
                checkMArkImage.gameObject.SetActive(true);
            } else {
                markImage.color = new Color(0.4f, 0.4f, 0.4f, 0.59f);
                checkMArkImage.gameObject.SetActive(false);
            }
        }
    }
}