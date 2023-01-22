using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace CozyGame
{
    public class DialogMenu : Menu
    {
        [SerializeField]
        private TextMeshProUGUI _dialogText;
        [SerializeField]
        private Button _button;
        [SerializeField]
        private TextMeshProUGUI _buttonText;

        protected override void Awake()
        {
            base.Awake();
            base.Close();
        }

        public override void Open()
        {
            SoundEffectsManager.Instance.PlayOpenWindow();
            base.Open();
        }

        public override void Close()
        {
            if (IsInteractable)
            {
                SoundEffectsManager.Instance.PlayCloseWindow(); 
            }

            base.Close();
        }

        public void SetDialog(DialogPlayer dialogPlayer, UnityAction action = null)
        {
            _dialogText.SetText(dialogPlayer.DialogText);
            _buttonText.SetText(dialogPlayer.ButtonText);

            if (action != null)
            {
                _button.onClick.RemoveAllListeners();
                _button.onClick.AddListener(action);
                _button.onClick.AddListener(() => base.Close());
            }
            else
            {
                _button.onClick.RemoveAllListeners();
                _button.onClick.AddListener(() => Close());
            }
        }
    }
}
