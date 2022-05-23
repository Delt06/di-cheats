using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Object = UnityEngine.Object;

namespace DELTation.DIFramework.Cheats
{
    [RequireComponent(typeof(CheatMenuRefs))]
    public abstract class CheatMenuBase : MonoBehaviour
    {
        private readonly List<ICheatMenuItem> _items = new List<ICheatMenuItem>();
        private CheatMenuRefs _refs;

        protected void Awake()
        {
            _refs = GetComponent<CheatMenuRefs>();
            Build();
            _refs.CloseButton.onClick.AddListener(OnCloseButtonClick);
        }

        private void OnEnable()
        {
            foreach (var item in _items)
            {
                item.OnEnabled();
            }
        }

        protected void OnDestroy()
        {
            _refs.CloseButton.onClick.RemoveListener(OnCloseButtonClick);
        }

        protected static T GetService<T>() where T : class => Di.TryResolveGlobally(out T service)
            ? service
            : throw new ArgumentException($"Could not find a service of type {typeof(T)}");

        private void OnCloseButtonClick() =>
            Close();

        private void Close()
        {
            gameObject.SetActive(false);
        }

        protected abstract void Build();

        protected void CreateButton(string text, UnityAction onClick)
        {
            CreateItem(_refs.ButtonPrefab)
                .Init(text, onClick);
        }

        protected void CreateInputField(string text, UnityAction<string> onValueChanged, Func<string> init)
        {
            CreateItem(_refs.InputFieldPrefab)
                .Init(text, onValueChanged, init);
        }

        protected void CreateInputFieldWithSubmission(string text,
            UnityAction<CheatMenuInputFieldWithSubmission.SubmissionArgs> onSubmit, Func<string> init)
        {
            CreateItem(_refs.InputFieldWithSubmissionPrefab)
                .Init(text, onSubmit, init);
        }

        protected void CreateToggle(string title, UnityAction<bool> onValueChanged, Func<bool> init)
        {
            CreateItem(_refs.TogglePrefab)
                .Init(title, onValueChanged, init);
        }


        private T CreateItem<T>(T prefab) where T : Object, ICheatMenuItem
        {
            var item = Instantiate(prefab, _refs.GridRoot);
            _items.Add(item);
            return item;
        }
    }
}