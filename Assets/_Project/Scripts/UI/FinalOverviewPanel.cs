using System;
using System.Collections;
using System.Linq;
using UnityEngine;

namespace _Project.Scripts.UI {
    public class FinalOverviewPanel : MonoBehaviour {
        [SerializeField] private CanvasGroup[] alphaElements;
        [SerializeField] private float fadeDuration = 0.5f;

        public void OnEnable() {
            foreach (var element in alphaElements) {
                element.alpha = 0;
            }
            
            StartCoroutine(SetAlphaCoroutine());
        }

        IEnumerator SetAlphaCoroutine() {
            // Проходим по каждому элементу из списка по очереди
            foreach (var element in alphaElements)
            {
                if (element == null) continue;

                float currentTime = 0f;

                // Плавно увеличиваем альфу от 0 до 1
                while (currentTime < fadeDuration)
                {
                    currentTime += Time.deltaTime;
                    element.alpha = Mathf.Lerp(0f, 1f, currentTime / fadeDuration);
                
                    // Ждем следующего кадра, чтобы анимация была плавной
                    yield return null; 
                }

                // На всякий случай жестко прописываем 1 в конце
                element.alpha = 1f;
            }
        }
    }
}