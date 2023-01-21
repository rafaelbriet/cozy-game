using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CozyGame
{
    public class TutorialCanvas : Menu
    {
        [SerializeField]
        private float _hideTimeInSeconds = 10f;

        protected override void Awake()
        {
            base.Awake();
            StartCoroutine(HideCoroutine());
        }

        public void ShowCanvas()
        {
            StopAllCoroutines();
            Open();
        }

        public void HideCanvas()
        {
            Close();
        }

        private IEnumerator HideCoroutine()
        {
            yield return new WaitForSeconds(_hideTimeInSeconds);
            HideCanvas();
        }
    }
}
