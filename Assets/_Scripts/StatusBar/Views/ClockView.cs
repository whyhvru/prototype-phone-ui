using System;
using LightSide;
using UnityEngine;

namespace Module.UI.StatusBar
{
    public sealed class ClockView : MonoBehaviour
    {
        [SerializeField] private UniText _clockText;

        private float _nextUpdateTime;

        private void Start() => UpdateClock();

        private void Update()
        {
            if (Time.unscaledTime < _nextUpdateTime)
                return;

            UpdateClock();
        }

        private void UpdateClock()
        {
            _clockText.Text = DateTime.Now.ToString("HH:mm");
            _nextUpdateTime = Time.unscaledTime + 1f;
        }
    }
}