using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Project.Scripts.UI {
    public class StepMarkCellView : MonoBehaviour {
        [Inject] private StepController StepController;
        
        [SerializeField] private Image markImage;

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
            markImage.sprite = isFinished ? finishSprite : notFinishSprite;
        }
    }
}