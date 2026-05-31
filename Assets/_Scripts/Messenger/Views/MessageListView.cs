using UnityEngine;
using UnityEngine.UI;

namespace Module.UI.Messenger.Views
{
    public sealed class MessageListView : MonoBehaviour
    {
        [SerializeField] private MessageBubbleView _messageBubbleLeft;
        [SerializeField] private MessageBubbleView _messageBubbleRight;
        [SerializeField] private RectTransform _contentRoot;

        public void AddMessage(string text, EMessageSide side)
        {
            if (string.IsNullOrWhiteSpace(text))
                return;

            CreateBubble(text, side);
        }

        private void CreateBubble(string text, EMessageSide side)
        {
            bool isLeft = side == EMessageSide.Left;
            var bubble = Instantiate(isLeft ? _messageBubbleLeft : _messageBubbleRight, _contentRoot);
            bubble.SetMessage(text);

            Canvas.ForceUpdateCanvases();
            LayoutRebuilder.ForceRebuildLayoutImmediate(_contentRoot);
        }
    }
}