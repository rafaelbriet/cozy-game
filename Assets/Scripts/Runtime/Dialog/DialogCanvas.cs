using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace CozyGame
{
    [RequireComponent(typeof(CanvasGroup))]
    public class DialogCanvas : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _dialogText;
        [SerializeField]
        private Button _button;
        [SerializeField]
        private TextMeshProUGUI _buttonText;

        private CanvasGroup _canvasGroup;
        private bool _playSoundeffects;

        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
            HideCanvas();
            _playSoundeffects = true;
        }

        public void ShowCanvas()
        {
            _canvasGroup.alpha = 1;
            _canvasGroup.interactable = true;
            _canvasGroup.blocksRaycasts = true;
            SoundEffectsManager.Instance.PlayOpenWindow();
        }

        public void HideCanvas()
        {
            _canvasGroup.alpha = 0;
            _canvasGroup.interactable = false;
            _canvasGroup.blocksRaycasts = false;

            if (_playSoundeffects)
            {
                SoundEffectsManager.Instance.PlayCloseWindow();
            }
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
