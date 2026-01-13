using System;
using _Project.Scripts.UI;
using TMPro;
using UnityEditor;
using UnityEngine;

namespace _Project.Scripts.UI
{
    public class NotificationPopUp : MonoBehaviour
    {
        public static NotificationPopUp instance;
        
        [SerializeField] private float showingTime = 5f;
        [SerializeField] private GameObject panel;
        [SerializeField] private TextMeshProUGUI text;

        private void Awake() {
            if (instance == null) {
                instance = this;
            }
        }
        
        public void ShowNotification(string _text) {
            text.text = _text;
            panel.SetActive(true);
            Invoke(nameof(CloseNotification), showingTime);
        }

        public void CloseNotification() {
            panel.SetActive(false);
        }
    }
}


#if UNITY_EDITOR

[CustomEditor(typeof(NotificationPopUp))]
public class NotificationPopUpEditor: Editor
{
    public override void OnInspectorGUI()
    {
        NotificationPopUp instance = (NotificationPopUp)target;
        base.OnInspectorGUI();

        if (GUILayout.Button("Show Notification"))
        {
            instance.ShowNotification("Show Notification");
        }
    }
}

#endif