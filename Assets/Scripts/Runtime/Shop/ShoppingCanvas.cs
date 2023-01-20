using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CozyGame
{
    [RequireComponent(typeof(CanvasGroup))]
    public class ShoppingCanvas : MonoBehaviour
    {
        private CanvasGroup _canvasGroup;

        public bool IsInteractable => _canvasGroup.interactable;

        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
            DisplayShop(false);
        }

        public void DisplayShop(bool display)
        {
            if (display)
            {
                _canvasGroup.alpha = 1;
                _canvasGroup.interactable = true;
                _canvasGroup.blocksRaycasts = true;
            }
            else
            {
                _canvasGroup.alpha = 0;
                _canvasGroup.interactable = false;
                _canvasGroup.blocksRaycasts = false;
            }
        }
    }
}
