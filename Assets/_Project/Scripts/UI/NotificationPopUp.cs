using System;
using System.Collections;
using _Project.Scripts.UI;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.UI
{
    public class NotificationPopUp : MonoBehaviour
    {
        public static NotificationPopUp instance;
        
        [SerializeField] private float showingTime = 5f;
        [SerializeField] private Image panel;
        
        [SerializeField] private Color noFoundColor;
        [SerializeField] private Color foundColor;

        [SerializeField] private GameObject arPopUp;
        [SerializeField] private TextMeshProUGUI arText;
        [SerializeField] private float delayBetweenLetters = 0.05f; // Скорость появления букв

        private string fullText = "סרוק את הרכיב";
        
        private Color panelBaseColor;
        private void Awake() {
            if (instance == null) {
                instance = this;
            }
            
            panelBaseColor = panel.color;
        }

        public void ShowStartScaningNotification(bool isStart) {
            if (isStart) {
                arPopUp.SetActive(true);
                StopAllCoroutines();
                StartCoroutine(ShowArTextCoroutine());
            }
            else {
                arPopUp.SetActive(false);
                StopAllCoroutines();
            }
        }
        
        public void ShowNotification(bool isFound) {
            if (isFound) {
                panel.color = foundColor;
            } else  {
                panel.color = noFoundColor;
            }
        }
        
        public void ResetPanel() {
            panel.color = panelBaseColor;
        }

        IEnumerator ShowArTextCoroutine() 
        {
            arText.text = ""; // Очищаем текст перед стартом

            // Цикл идет по каждой букве строки
            foreach (char letter in fullText)
            {
                arText.text += letter; // Добавляем по одной букве
                yield return new WaitForSeconds(delayBetweenLetters); // Ждем указанное время
            }
        }
        
    }
}
