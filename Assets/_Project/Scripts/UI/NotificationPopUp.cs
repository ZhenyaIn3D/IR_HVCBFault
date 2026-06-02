using System;
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


        private Color panelBaseColor;
        private void Awake() {
            if (instance == null) {
                instance = this;
            }
            
            panelBaseColor = panel.color;
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
    }
}
