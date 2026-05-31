using System;
using LightSide;
using UnityEngine;
using UnityEngine.UI;

namespace Module.UI.Messenger.Views
{
    public sealed class MessageBubbleView : MonoBehaviour
    {
        [SerializeField] private UniText _messageText;
        [SerializeField] private UniText _timeText;
        [SerializeField] private RectTransform _bubbleRect;

        public void SetMessage(string message)
        {
            _messageText.Text = message;
            _timeText.Text = DateTime.Now.ToString("HH:mm");

            LayoutRebuilder.ForceRebuildLayoutImmediate(_bubbleRect);
        }
    }
}