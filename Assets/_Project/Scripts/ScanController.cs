using System;
using _Project.Scripts.UI;
using UnityEngine;
using Vuforia;

public class ScanController : MonoBehaviour
{
    [Header("Перетащите сюда ваш Area Target или Image Target")]
    public ObserverBehaviour targetObserver;

    [Header("Статус (для проверки)")]
    [SerializeField] private bool isScanning = true;

    public Action OnScanFound;
    public Action OnScanLost;
    
    // Вызовите эту функцию кнопкой "Начать"
    public void StartScanning()
    {
        if (targetObserver != null)
        {
            targetObserver.enabled = true; // Включаем компонент Vuforia
            isScanning = true;
            NotificationPopUp.instance.ShowNotification("Start scanning target, move camera smoothly");
        }
    }

    // Вызовите эту функцию кнопкой "Стоп"
    public void StopScanning() {
        if (targetObserver != null)
        {
            targetObserver.enabled = false; // Отключаем компонент
            isScanning = false;
            Debug.Log("Vuforia: Поиск цели ОСТАНОВЛЕН");
        }
    }
    
    public void ScanFound() {
        Debug.Log("ScanFound");
        OnScanFound?.Invoke();
        NotificationPopUp.instance.ShowNotification("Scan found target");
    }

    public void ScanLost() {
        Debug.Log("ScanLost");
        OnScanLost?.Invoke();
        NotificationPopUp.instance.ShowNotification("Scan lost target");
    }
}
