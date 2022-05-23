using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace DELTation.DIFramework.Cheats
{
    public class CheatMenuButton : MonoBehaviour, ICheatMenuItem
    {
        [SerializeField] private Button _button;
        [SerializeField] private TMP_Text _text;
        private UnityAction _onClick;

        private void OnDestroy()
        {
            if (_onClick != null)
                _button.onClick.RemoveListener(_onClick);
        }

        public void OnEnabled() { }

        public void Init(string text, UnityAction onClick)
        {
            _onClick = onClick;
            _button.onClick.AddListener(onClick);
            _text.text = text;
        }
    }
}