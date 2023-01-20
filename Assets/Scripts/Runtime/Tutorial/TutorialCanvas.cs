using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CozyGame
{
    [RequireComponent(typeof(CanvasGroup))]
    public class TutorialCanvas : MonoBehaviour
    {
        [SerializeField]
        private float _hideTimeInSeconds = 10f;

        private CanvasGroup _canvasGroup;

        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
            StartCoroutine(HideCoroutine());
        }

        public void ShowCanvas()
        {
            StopAllCoroutines();
            _canvasGroup.alpha = 1;
            _canvasGroup.interactable = true;
            _canvasGroup.blocksRaycasts = true;
        }

        public void HideCanvas()
        {
            _canvasGroup.alpha = 0;
            _canvasGroup.interactable = false;
            _canvasGroup.blocksRaycasts = false;
        }

        private IEnumerator HideCoroutine()
        {
            yield return new WaitForSeconds(_hideTimeInSeconds);
            HideCanvas();
        }
    }
}
