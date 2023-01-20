using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CozyGame
{
    [RequireComponent(typeof(CanvasGroup))]
    public class ShoppingCanvas : MonoBehaviour
    {
        [SerializeField]
        private RectTransform _shopkeeperInventoryContainer;
        [SerializeField]
        private ShopShopkeeperInventorySlot _shopkeeperInventorySlot;

        private CanvasGroup _canvasGroup;
        private Inventory _shopkeeperInventory;

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

        public void DisplayShop(bool display, Inventory shopkeeperInventory)
        {
            DisplayShop(display);
            _shopkeeperInventory = shopkeeperInventory;
            UpdateInventoryContent();
        }

        private void UpdateInventoryContent()
        {
            CleanShopkeeperInventoryContainer();

            foreach (Item item in _shopkeeperInventory.Items)
            {
                ShopShopkeeperInventorySlot shopkeeperInventorySlot = Instantiate(_shopkeeperInventorySlot, _shopkeeperInventoryContainer);
                shopkeeperInventorySlot.Init(item);
            }
        }

        private void CleanShopkeeperInventoryContainer()
        {
            foreach (RectTransform slot in _shopkeeperInventoryContainer)
            {
                Destroy(slot.gameObject);
            }
        }
    }
}
