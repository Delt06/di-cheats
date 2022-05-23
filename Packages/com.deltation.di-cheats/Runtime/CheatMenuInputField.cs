using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace DELTation.DIFramework.Cheats
{
    public class CheatMenuInputField : MonoBehaviour, ICheatMenuItem
    {
        [SerializeField] private TMP_InputField _inputField;
        [SerializeField] private TMP_Text _title;
        private Func<string> _init;

        private UnityAction<string> _onValueChanged;

        private void OnDestroy()
        {
            if (_onValueChanged != null)
                _inputField.onValueChanged.RemoveListener(_onValueChanged);
        }

        public void OnEnabled()
        {
            _inputField.text = _init();
        }

        public void Init(string text, UnityAction<string> onValueChanged, Func<string> init)
        {
            _init = init;
            _onValueChanged = onValueChanged;
            _inputField.onValueChanged.AddListener(onValueChanged);
            _title.text = text;
        }
    }
}