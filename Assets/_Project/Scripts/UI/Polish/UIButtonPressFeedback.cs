using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace _Project.Scripts.UI.Polish {
    // Лёгкое «нажатие» кнопки: плавно уменьшается, пока палец на ней, и возвращается обратно
    [RequireComponent(typeof(Selectable))]
    public class UIButtonPressFeedback : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler {
        [SerializeField] private float pressedScale = 0.95f;
        [SerializeField] private float speed = 18f;

        private Selectable selectable;
        private Vector3 baseScale = Vector3.one;
        private bool isPressed;

        private void Awake() {
            selectable = GetComponent<Selectable>();
            baseScale = transform.localScale;
        }

        private void OnDisable() {
            isPressed = false;
            transform.localScale = baseScale;
        }

        public void OnPointerDown(PointerEventData eventData) {
            isPressed = selectable.IsInteractable();
        }

        public void OnPointerUp(PointerEventData eventData) {
            isPressed = false;
        }

        public void OnPointerExit(PointerEventData eventData) {
            isPressed = false;
        }

        private void Update() {
            var goal = isPressed ? baseScale * pressedScale : baseScale;
            transform.localScale = Vector3.Lerp(transform.localScale, goal, 1f - Mathf.Exp(-speed * Time.unscaledDeltaTime));
        }
    }
}
