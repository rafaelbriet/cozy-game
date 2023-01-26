using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CozyGame
{
    public class TutorialMenu : Menu
    {
        [SerializeField]
        private float _hideTimeInSeconds = 10f;

        protected override void Awake()
        {
            StartCoroutine(HideCoroutine());
            base.Awake();
        }

        public override void Open()
        {
            StopAllCoroutines();
            base.Open();
        }

        private IEnumerator HideCoroutine()
        {
            yield return new WaitForSeconds(_hideTimeInSeconds);
            base.Close();
        }
    }
}
