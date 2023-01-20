using System;
using UnityEngine;

namespace CozyGame
{
    [RequireComponent(typeof(CanvasGroup))]
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField]
        private TutorialCanvas _tutorialCanvas;

        private CanvasGroup _canvasGroup;

        public event Action Opened;
        public event Action Closed;

        public bool IsInteractable => _canvasGroup.interactable;

        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
            HideCanvas();
        }

        public void Pause()
        {
            ShowCanvas();
            _tutorialCanvas.ShowCanvas();
            SoundEffectsManager.Instance.PlayPaused();
            Opened?.Invoke();
        }

        public void Unpause()
        {
            HideCanvas();
            _tutorialCanvas.HideCanvas();
            SoundEffectsManager.Instance.PlayUnpause();
            Closed?.Invoke();
        }

        public void Quit()
        {
#if UNITY_EDITOR
            UnityEngine.Debug.Log("Application quit.");

#else
        Application.Quit();
#endif
        }

        private void ShowCanvas()
        {
            _canvasGroup.alpha = 1;
            _canvasGroup.interactable = true;
            _canvasGroup.blocksRaycasts = true;
        }

        private void HideCanvas()
        {
            _canvasGroup.alpha = 0;
            _canvasGroup.interactable = false;
            _canvasGroup.blocksRaycasts = false;
        }
    }
}
