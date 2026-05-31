using Module.UI.Messenger.Controllers;
using Module.UI.Messenger.Views;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

namespace Module.UI.Messenger.Input
{
    public sealed class ChatInputController : MonoBehaviour
    {
        [SerializeField] private ChatInputView _chatInputView;
        [SerializeField] private MessengerController _messengerController;
        [SerializeField] private float _backspaceInitialDelay = 0.5f;
        [SerializeField] private float _backspaceRepeatRate = 0.05f;

        private KeyboardCharacterReader _characterReader;
        private BackspaceRepeater _backspaceRepeater;

        private void Awake()
        {
            _characterReader = new KeyboardCharacterReader();
            _backspaceRepeater = new BackspaceRepeater(_backspaceInitialDelay, _backspaceRepeatRate);
        }

        private void Update()
        {
            var keyboard = Keyboard.current;
            if (keyboard == null)
                return;

            HandlePressedKeys(keyboard);
            HandleBackspaceRepeat(keyboard);
        }

        private void HandlePressedKeys(Keyboard keyboard)
        {
            foreach (var key in keyboard.allKeys)
            {
                if (!key.wasPressedThisFrame)
                    continue;

                if (TryHandleSpecialKey(keyboard, key))
                    continue;

                TryAppendCharacter(keyboard, key);
            }
        }

        private bool TryHandleSpecialKey(Keyboard keyboard, KeyControl key)
        {
            if (key == keyboard.enterKey)
            {
                SubmitMessage();
                return true;
            }

            if (key == keyboard.backspaceKey)
            {
                PressBackspace();
                return true;
            }

            if (key == keyboard.spaceKey)
            {
                _chatInputView.AppendChar(' ');
                return true;
            }

            return false;
        }

        private void SubmitMessage()
        {
            string text = _chatInputView.Text;

            if (string.IsNullOrWhiteSpace(text))
                return;

            _messengerController.SendPlayerMessage(text);
            _chatInputView.Text = string.Empty;
        }

        private void PressBackspace()
        {
            _chatInputView.Backspace();
            _backspaceRepeater.StartDelay();
        }

        private void HandleBackspaceRepeat(Keyboard keyboard)
        {
            if (_backspaceRepeater.ShouldRepeat(keyboard.backspaceKey, Time.time))
                _chatInputView.Backspace();
        }

        private void TryAppendCharacter(Keyboard keyboard, KeyControl key)
        {
            if (!_characterReader.TryRead(keyboard, key, out char character))
                return;

            _chatInputView.AppendChar(character);
        }
    }
}