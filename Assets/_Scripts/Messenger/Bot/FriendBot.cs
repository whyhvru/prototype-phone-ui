using System.Collections;
using Module.UI.Messenger.Controllers;
using UnityEngine;

namespace Module.UI.Messenger.Bot
{
    public sealed class FriendBot : MonoBehaviour
    {
        [SerializeField] private MessengerController _messengerController;
        [SerializeField] private float _minDelay = 3f;
        [SerializeField] private float _maxDelay = 7f;

        private void Start() => StartCoroutine(SendRandomMessages());

        private IEnumerator SendRandomMessages()
        {
            while (true)
            {
                float delay = Random.Range(_minDelay, _maxDelay);
                yield return new WaitForSeconds(delay);

                string message = FriendMessagePool.GetRandomMessage();
                _messengerController.SendFriendMessage(message);
            }
        }
    }
}