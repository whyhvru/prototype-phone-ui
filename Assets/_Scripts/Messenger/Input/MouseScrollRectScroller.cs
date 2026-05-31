using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Module.UI.Messenger.Input
{
    public sealed class MouseScrollRectScroller : MonoBehaviour
    {
        [SerializeField] private ScrollRect _scrollRect;
        [SerializeField] private float _scrollStepInPixels = 200f;
        [SerializeField] private float _smoothSpeed = 10f;

        private float _targetVerticalPos;

        private void OnEnable() => _targetVerticalPos = _scrollRect.verticalNormalizedPosition;

        private void Update()
        {
            var mouse = Mouse.current;
            if (mouse == null)
                return;

            float scrollInput = mouse.scroll.ReadValue().y;
            if (Mathf.Abs(scrollInput) > 0.1f)
            {
                float contentHeight = _scrollRect.content.rect.height;
                float viewportHeight = _scrollRect.viewport.rect.height;

                float scrollableHeight = contentHeight - viewportHeight;
                if (scrollableHeight <= 0) return;

                float normalizedStep = _scrollStepInPixels / scrollableHeight;
                float direction = Mathf.Sign(scrollInput);

                _targetVerticalPos += direction * normalizedStep;
                _targetVerticalPos = Mathf.Clamp01(_targetVerticalPos);
            }

            if (Mathf.Abs(_scrollRect.verticalNormalizedPosition - _targetVerticalPos) > 0.0001f)
            {
                _scrollRect.verticalNormalizedPosition = Mathf.Lerp(
                    _scrollRect.verticalNormalizedPosition,
                    _targetVerticalPos,
                    Time.deltaTime * _smoothSpeed
                );
            }
            else
            {
                _scrollRect.verticalNormalizedPosition = _targetVerticalPos;
            }
        }
    }
}