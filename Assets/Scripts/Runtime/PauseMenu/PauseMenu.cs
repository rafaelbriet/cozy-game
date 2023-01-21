using System;
using UnityEngine;

namespace CozyGame
{
    public class PauseMenu : Menu
    {
        [SerializeField]
        private TutorialCanvas _tutorialCanvas;

        protected override void Awake()
        {
            base.Awake();
            Close();
        }

        public void Pause()
        {
            SoundEffectsManager.Instance.PlayPaused();
            _tutorialCanvas.ShowCanvas();
            Open();
        }

        public void Unpause()
        {
            SoundEffectsManager.Instance.PlayUnpause();
            _tutorialCanvas.HideCanvas();
            Close();
        }

        public void Quit()
        {
#if UNITY_EDITOR
            UnityEngine.Debug.Log("Application quit.");

#else
        Application.Quit();
#endif
        }
    }
}
