using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace DELTation.DIFramework.Cheats
{
    public class CheatMenuInputFieldWithSubmission : MonoBehaviour, ICheatMenuItem
    {
        [SerializeField] private TMP_InputField _inputField;
        [SerializeField] private TMP_Text _title;

        private Func<string> _init;
        private UnityAction<SubmissionArgs> _onSubmit;

        private void OnDestroy()
        {
            if (_onSubmit != null)
                _inputField.onSubmit.RemoveListener(OnSubmit);
        }

        public void OnEnabled()
        {
            _inputField.text = _init();
        }

        public void Init(string text, UnityAction<SubmissionArgs> onSubmit, Func<string> init)
        {
            _onSubmit = onSubmit;
            _init = init;
            _inputField.onSubmit.AddListener(OnSubmit);
            _title.text = text;
        }

        private void OnSubmit(string arg0) =>
            _onSubmit(new SubmissionArgs(this, arg0));

        public readonly struct SubmissionArgs
        {
            private readonly CheatMenuInputFieldWithSubmission _inputField;
            public readonly string Text;

            public SubmissionArgs(CheatMenuInputFieldWithSubmission inputField, string text)
            {
                _inputField = inputField;
                Text = text;
            }

            public void ReportError(string error) => _inputField._inputField.text = error;
        }
    }
}