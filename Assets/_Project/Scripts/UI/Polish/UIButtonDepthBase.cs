using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.UI.Polish {
    // Тёмное основание объёмной кнопки. Стоит в иерархии перед кнопкой, повторяет её форму
    // и всегда находится на CurrentDepth ниже лицевой части; прячется вместе с кнопкой.
    [ExecuteAlways]
    [RequireComponent(typeof(Graphic))]
    public class UIButtonDepthBase : MonoBehaviour {
        [SerializeField] private UIButton3D button;

        private RectTransform rectTransform;
        private Graphic graphic;
        private readonly Vector3[] corners = new Vector3[4];

        private void OnEnable() {
            rectTransform = (RectTransform)transform;
            graphic = GetComponent<Graphic>();
            graphic.raycastTarget = false;
        }

        private void LateUpdate() {
            if (button == null || rectTransform.parent == null) return;

            var visible = button.gameObject.activeInHierarchy;
            if (graphic.enabled != visible) graphic.enabled = visible;
            if (!visible) return;

            var target = (RectTransform)button.transform;
            var parent = (RectTransform)rectTransform.parent;
            target.GetWorldCorners(corners);
            Vector2 min = parent.InverseTransformPoint(corners[0]);
            Vector2 max = parent.InverseTransformPoint(corners[2]);

            rectTransform.anchorMin = rectTransform.anchorMax = rectTransform.pivot = new Vector2(0.5f, 0.5f);
            rectTransform.sizeDelta = target.rect.size;
            rectTransform.localPosition = (Vector3)((min + max) * 0.5f - new Vector2(0f, button.CurrentDepth));
            rectTransform.localRotation = Quaternion.identity;
            rectTransform.localScale = Vector3.one;
        }
    }
}
