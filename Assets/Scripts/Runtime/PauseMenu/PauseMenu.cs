using System;
using UnityEngine;

namespace CozyGame
{
    public class PauseMenu : Menu
    {
        [SerializeField]
        private TutorialMenu _tutorialCanvas;

        protected override void Awake()
        {
            base.Awake();
            base.Close();
        }

        public override void Open()
        {
            SoundEffectsManager.Instance.PlayPaused();
            _tutorialCanvas.Open();
            base.Open();
        }

        public override void Close()
        {
            SoundEffectsManager.Instance.PlayUnpause();
            _tutorialCanvas.Close();
            base.Close();
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
