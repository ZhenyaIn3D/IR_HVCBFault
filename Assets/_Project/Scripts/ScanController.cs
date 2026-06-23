using System;
using _Project.Scripts.UI;
using UnityEngine;
using Vuforia;

public class ScanController : MonoBehaviour
{
    [Header("Перетащите сюда ваш Area Target или Image Target")]
    public ObserverBehaviour[] targetsObserver;

    [Header("Статус (для проверки)")]
    [SerializeField] private bool isScanning = true;

    public Action OnScanFound;
    public Action OnScanLost;
    
    private ObserverBehaviour currentTargetObserver;
    public void StartScanning(int index) {
        if (currentTargetObserver != null) {
            currentTargetObserver.enabled = false;
            currentTargetObserver.gameObject.SetActive(false);
        }
        
        currentTargetObserver = targetsObserver[index];
        if (currentTargetObserver != null) {
            currentTargetObserver.gameObject.SetActive(true);
            currentTargetObserver.enabled = true; // Включаем компонент Vuforia
            isScanning = true;
            NotificationPopUp.instance.ShowStartScaningNotification(true);
        }
    }
    
    
    public void ScanFound() {
        OnScanFound?.Invoke();
        NotificationPopUp.instance.ShowNotification(true);
        NotificationPopUp.instance.ShowStartScaningNotification(false);
    }

    public void ScanLost() {
        OnScanLost?.Invoke();
        NotificationPopUp.instance.ShowNotification(false);
    }
}
