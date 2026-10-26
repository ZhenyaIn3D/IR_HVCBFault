using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace _Project.Scripts.UI.Polish {
    // Объёмная кнопка: лицевая часть приподнята над тёмным основанием (UIButtonDepthBase)
    // и при нажатии «вдавливается» в него
    [RequireComponent(typeof(Selectable))]
    public class UIButton3D : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler {
        [SerializeField] private float depth = 8f;
        [SerializeField] private float pressedDepth = 1.5f;
        [SerializeField] private float pressedScale = 0.985f;
        [SerializeField] private float speed = 22f;

        private RectTransform rectTransform;
        private Selectable selectable;
        private Vector2 basePosition;
        private float currentDepth;
        private bool isPressed;
        private bool canMove;

        // Насколько лицевая часть сейчас над основанием
        public float CurrentDepth => Application.isPlaying && rectTransform != null ? currentDepth : depth;

        private void Awake() {
            rectTransform = (RectTransform)transform;
            selectable = GetComponent<Selectable>();
            // Внутри LayoutGroup позицию двигать нельзя: там кнопка стоит, а основание поднимается под неё
            canMove = transform.parent == null || transform.parent.GetComponent<LayoutGroup>() == null;
            basePosition = rectTransform.anchoredPosition;
            currentDepth = depth;
        }

        private void OnDisable() {
            isPressed = false;
            currentDepth = depth;
            if (canMove) rectTransform.anchoredPosition = basePosition;
            rectTransform.localScale = Vector3.one;
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
            var k = 1f - Mathf.Exp(-speed * Time.unscaledDeltaTime);
            currentDepth = Mathf.Lerp(currentDepth, isPressed ? pressedDepth : depth, k);
            var scale = Mathf.Lerp(rectTransform.localScale.x, isPressed ? pressedScale : 1f, k);
            rectTransform.localScale = new Vector3(scale, scale, 1f);
            if (canMove) rectTransform.anchoredPosition = basePosition - new Vector2(0f, depth - currentDepth);
        }
    }
}
