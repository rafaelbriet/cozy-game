using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace CozyGame
{
    public class DialogCanvas : Menu
    {
        [SerializeField]
        private TextMeshProUGUI _dialogText;
        [SerializeField]
        private Button _button;
        [SerializeField]
        private TextMeshProUGUI _buttonText;

        private bool _playSoundeffects;

        protected override void Awake()
        {
            base.Awake();
            Close();
            _playSoundeffects = true;
        }

        public void ShowCanvas()
        {
            SoundEffectsManager.Instance.PlayOpenWindow();
            Open();
        }

        public void HideCanvas()
        {
            if (_playSoundeffects && IsInteractable)
            {
                SoundEffectsManager.Instance.PlayCloseWindow();
            }

            Close();
        }

        public void SetDialog(DialogPlayer dialogPlayer, UnityAction action = null)
        {
            _dialogText.SetText(dialogPlayer.DialogText);
            _buttonText.SetText(dialogPlayer.ButtonText);

            if (action != null)
            {
                _button.onClick.AddListener(action);
            }
            else
            {
                _button.onClick.RemoveAllListeners();
            }
        }
    }
}
