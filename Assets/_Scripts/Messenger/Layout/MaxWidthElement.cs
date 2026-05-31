using UnityEngine;
using UnityEngine.UI;

namespace Module.UI.Messenger.Layout
{
    [RequireComponent(typeof(RectTransform))]
    public sealed class MaxWidthElement : MonoBehaviour, ILayoutSelfController
    {
        [SerializeField] private RectTransform _rectTransform;
        [SerializeField] private float _maxWidth = 500f;

        private void Awake()
        {
            if (_rectTransform == null)
                _rectTransform = GetComponent<RectTransform>();
        }

        private void OnValidate()
        {
            if (_rectTransform == null)
                _rectTransform = GetComponent<RectTransform>();
        }

        public void SetLayoutHorizontal()
        {
            if (_rectTransform == null)
                return;

            if (_rectTransform.sizeDelta.x > _maxWidth)
            {
                _rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, _maxWidth);
            }
        }

        public void SetLayoutVertical() { }
    }
}