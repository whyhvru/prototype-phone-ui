using Module.UI.Messenger.Views;
using UnityEngine;

namespace Module.UI.Messenger.Controllers
{
    public sealed class MessengerController : MonoBehaviour
    {
        [SerializeField] private MessageListView _messageList;

        public void SendPlayerMessage(string text) => SendMessage(text, EMessageSide.Right);
        public void SendFriendMessage(string text) => SendMessage(text, EMessageSide.Left);

        private void SendMessage(string text, EMessageSide side)
        {
            if (string.IsNullOrWhiteSpace(text))
                return;

            _messageList.AddMessage(text, side);
        }
    }
}