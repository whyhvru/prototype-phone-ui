using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

namespace Module.UI.Messenger.Input
{
    public sealed class KeyboardCharacterReader
    {
        private static readonly Dictionary<char, char> _shiftMap = new()
        {
            { '1', '!' }, { '2', '@' }, { '3', '#' }, { '4', '$' }, { '5', '%' },
            { '6', '^' }, { '7', '&' }, { '8', '*' }, { '9', '(' }, { '0', ')' },
            { '-', '_' }, { '=', '+' }, { '[', '{' }, { ']', '}' }, { '\\', '|' },
            { ';', ':' }, { '\'', '"' }, { ',', '<' }, { '.', '>' }, { '/', '?' },
            { '`', '~' }
        };

        public bool TryRead(Keyboard keyboard, KeyControl key, out char character)
        {
            character = default;

            if (!TryGetRawCharacter(key, out char rawCharacter))
                return false;

            character = ApplyModifiers(keyboard, rawCharacter);
            return true;
        }

        private static bool TryGetRawCharacter(KeyControl key, out char character)
        {
            if (TryGetSingleCharacter(key.displayName, out character))
                return true;

            if (TryGetSingleCharacter(key.name, out character))
                return true;

            return false;
        }

        private static bool TryGetSingleCharacter(string value, out char character)
        {
            character = default;

            if (string.IsNullOrEmpty(value) || value.Length != 1)
                return false;

            character = value[0];
            return true;
        }

        private static char ApplyModifiers(Keyboard keyboard, char character)
        {
            bool shift = IsShiftPressed(keyboard);

            if (char.IsLetter(character))
            {
                return shift ? char.ToUpperInvariant(character) : char.ToLowerInvariant(character);
            }

            if (shift && _shiftMap.TryGetValue(character, out char shiftedCharacter))
                return shiftedCharacter;

            return character;
        }

        private static bool IsShiftPressed(Keyboard keyboard)
            => IsPressed(keyboard.leftShiftKey)
            || IsPressed(keyboard.rightShiftKey);

        private static bool IsPressed(KeyControl key) => key != null && key.isPressed;
    }
}