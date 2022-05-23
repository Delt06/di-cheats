using UnityEngine;
using UnityEngine.UI;

namespace DELTation.DIFramework.Cheats
{
    public class CheatMenuRefs : MonoBehaviour
    {
        [SerializeField] private CheatMenuButton _buttonPrefab;
        [SerializeField] private CheatMenuInputField _inputFieldPrefab;
        [SerializeField] private CheatMenuInputFieldWithSubmission _inputFieldWithSubmissionPrefab;
        [SerializeField] private CheatMenuToggle _togglePrefab;
        [SerializeField] private RectTransform _gridRoot;
        [SerializeField] private Button _closeButton;

        public CheatMenuButton ButtonPrefab => _buttonPrefab;
        public CheatMenuInputField InputFieldPrefab => _inputFieldPrefab;

        public CheatMenuInputFieldWithSubmission InputFieldWithSubmissionPrefab => _inputFieldWithSubmissionPrefab;

        public CheatMenuToggle TogglePrefab => _togglePrefab;

        public RectTransform GridRoot => _gridRoot;

        public Button CloseButton => _closeButton;
    }
}