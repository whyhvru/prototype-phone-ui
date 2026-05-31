using UnityEngine.InputSystem.Controls;

namespace Module.UI.Messenger.Input
{
    public sealed class BackspaceRepeater
    {
        private readonly float _initialDelay;
        private readonly float _repeatRate;

        private float _nextRepeatTime;

        public BackspaceRepeater(float initialDelay, float repeatRate)
        {
            _initialDelay = initialDelay;
            _repeatRate = repeatRate;
        }

        public void StartDelay() => _nextRepeatTime = UnityEngine.Time.time + _initialDelay;

        public bool ShouldRepeat(KeyControl backspaceKey, float currentTime)
        {
            if (backspaceKey == null)
                return false;

            if (!backspaceKey.isPressed)
            {
                _nextRepeatTime = 0f;
                return false;
            }

            if (backspaceKey.wasPressedThisFrame)
                return false;

            if (_nextRepeatTime <= 0f)
                return false;

            if (currentTime < _nextRepeatTime)
                return false;

            _nextRepeatTime = currentTime + _repeatRate;
            return true;
        }
    }
}