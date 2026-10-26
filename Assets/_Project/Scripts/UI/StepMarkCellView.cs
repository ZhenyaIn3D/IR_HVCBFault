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
                markImage.color = new Color32(0x12, 0x84, 0x66, 0xFF); // success, белая галочка 4.65:1
                checkMArkImage.gameObject.SetActive(true);
            } else {
                markImage.color = new Color32(0xB8, 0xBB, 0xCB, 0xFF); // нейтральный серо-синий из палитры
                checkMArkImage.gameObject.SetActive(false);
            }
        }
    }
}