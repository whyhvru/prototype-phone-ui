using LightSide;
using UnityEngine;

namespace Module.UI.Messenger.Views
{
    public sealed class ChatInputView : MonoBehaviour
    {
        [SerializeField] private UniText _inputText;

        public string Text
        {
            get => _inputText.Text;
            set => _inputText.Text = value ?? string.Empty;
        }

        private void Awake() => Text = string.Empty;
        public void AppendChar(char c) => Text += c;

        public void Backspace()
        {
            if (string.IsNullOrEmpty(Text)) return;

            Text = Text[..^1];
        }
    }
}