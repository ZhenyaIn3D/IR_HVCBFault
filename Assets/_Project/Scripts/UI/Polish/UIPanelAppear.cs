using System.Collections;
using UnityEngine;

namespace _Project.Scripts.UI.Polish {
    // Плавное появление панели при каждом включении: прозрачность 0 -> 1 и лёгкое «наплывание»
    [RequireComponent(typeof(CanvasGroup))]
    public class UIPanelAppear : MonoBehaviour {
        [SerializeField] private float duration = 0.3f;
        [SerializeField] private float startScale = 0.98f;
        [SerializeField] private Vector2 startOffset = new Vector2(0f, -12f);

        private CanvasGroup canvasGroup;
        private RectTransform rectTransform;
        private Vector2 basePosition;
        private bool hasBasePosition;

        private void Awake() {
            canvasGroup = GetComponent<CanvasGroup>();
            rectTransform = (RectTransform)transform;
        }

        private void OnEnable() {
            if (!hasBasePosition) {
                basePosition = rectTransform.anchoredPosition;
                hasBasePosition = true;
            }
            StartCoroutine(AppearCoroutine());
        }

        private void OnDisable() {
            canvasGroup.alpha = 1f;
            rectTransform.localScale = Vector3.one;
            rectTransform.anchoredPosition = basePosition;
        }

        private IEnumerator AppearCoroutine() {
            float time = 0f;
            while (time < duration) {
                // Ease-out cubic
                var t = 1f - Mathf.Pow(1f - time / duration, 3f);
                canvasGroup.alpha = t;
                rectTransform.localScale = Vector3.one * Mathf.Lerp(startScale, 1f, t);
                rectTransform.anchoredPosition = basePosition + startOffset * (1f - t);
                time += Time.unscaledDeltaTime;
                yield return null;
            }

            canvasGroup.alpha = 1f;
            rectTransform.localScale = Vector3.one;
            rectTransform.anchoredPosition = basePosition;
        }
    }
}
