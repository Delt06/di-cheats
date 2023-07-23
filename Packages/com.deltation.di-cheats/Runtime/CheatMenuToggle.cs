using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace DELTation.DIFramework.Cheats
{
    public class CheatMenuToggle : MonoBehaviour, ICheatMenuItem
    {
        [SerializeField] private TMP_Text _title;
        [SerializeField] private Toggle _toggle;

        private Func<bool> _init;
        private UnityAction<bool> _onValueChanged;

        private void OnDestroy()
        {
            if (_onValueChanged != null)
                _toggle.onValueChanged.RemoveListener(_onValueChanged);
        }

        public void OnEnabled()
        {
            _toggle.isOn = _init();
        }

        public void Init(string title, UnityAction<bool> onValueChanged, Func<bool> init)
        {
            _init = init;
            _onValueChanged = onValueChanged;
            _toggle.onValueChanged.AddListener(onValueChanged);
            _title.text = title;
        }
    }
}