using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.UI.Polish {
    // Мягкая тень под элементом. Вешается на отдельный объект-сосед, который стоит в иерархии
    // перед целью: рисуется под ней и повторяет её размер, позицию, масштаб и видимость.
    [ExecuteAlways]
    [RequireComponent(typeof(Image))]
    public class UISoftShadow : MonoBehaviour {
        // Отступ размытой фигуры от края текстуры, в пикселях текстуры
        private const float TextureInset = 70f;

        [SerializeField] private RectTransform target;
        [SerializeField] private Color color = new Color(0.03f, 0.02f, 0.15f, 0.4f);
        [SerializeField] private Vector2 offset = new Vector2(0f, -10f);
        [SerializeField, Range(0.25f, 2f)] private float softness = 0.6f;
        [SerializeField] private float spread;

        private RectTransform rectTransform;
        private Image image;
        private CanvasGroup targetGroup;
        private Graphic targetGraphic;
        private readonly Vector3[] corners = new Vector3[4];

        public void Setup(RectTransform shadowTarget, Color shadowColor, Vector2 shadowOffset, float shadowSoftness) {
            target = shadowTarget;
            color = shadowColor;
            offset = shadowOffset;
            softness = shadowSoftness;
            targetGroup = null;
        }

        private void OnEnable() {
            rectTransform = (RectTransform)transform;
            image = GetComponent<Image>();
            image.raycastTarget = false;
            image.type = Image.Type.Sliced;
        }

        private void LateUpdate() {
            if (target == null || rectTransform.parent == null) return;

            if (targetGraphic == null) targetGraphic = target.GetComponent<Graphic>();
            var visible = target.gameObject.activeInHierarchy && (targetGraphic == null || targetGraphic.enabled);
            if (image.enabled != visible) image.enabled = visible;
            if (!visible) return;

            // Тень проявляется вместе с целью, если та плавно появляется через CanvasGroup
            if (targetGroup == null) targetGroup = target.GetComponent<CanvasGroup>();
            var tint = color;
            if (targetGroup != null) tint.a *= targetGroup.alpha;
            image.color = tint;

            image.pixelsPerUnitMultiplier = 1f / softness;

            var parent = (RectTransform)rectTransform.parent;
            target.GetWorldCorners(corners);
            Vector2 min = parent.InverseTransformPoint(corners[0]);
            Vector2 max = parent.InverseTransformPoint(corners[2]);

            var grow = TextureInset * softness + spread;
            rectTransform.anchorMin = rectTransform.anchorMax = rectTransform.pivot = new Vector2(0.5f, 0.5f);
            rectTransform.sizeDelta = (max - min) + Vector2.one * grow * 2f;
            rectTransform.localPosition = (Vector3)((min + max) * 0.5f + offset);
            rectTransform.localRotation = Quaternion.identity;
            rectTransform.localScale = Vector3.one;
        }
    }
}
