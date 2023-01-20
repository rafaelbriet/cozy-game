using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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
        [SerializeField]
        private TextMeshProUGUI _shopkeeperMoney;
        [SerializeField]
        private RectTransform _playerInventoryContainer;
        [SerializeField]
        private ShopPlayerInventorySlot _playerInventorySlot;
        [SerializeField]
        private TextMeshProUGUI _playerMoney;

        private CanvasGroup _canvasGroup;
        private Inventory _shopkeeperInventory;
        private Inventory _playerInventory;

        public bool IsInteractable => _canvasGroup.interactable;

        public event Action ShoppingOpened;
        public event Action ShoppingClosed;

        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
            DisplayShop(false, false);
        }

        public void Close()
        {
            DisplayShop(false);
        }

        public void DisplayShop(bool display, bool playSoundEffects = true)
        {
            if (display)
            {
                _canvasGroup.alpha = 1;
                _canvasGroup.interactable = true;
                _canvasGroup.blocksRaycasts = true;
                
                if (playSoundEffects)
                {
                    SoundEffectsManager.Instance.PlayOpenWindow(); 
                }

                ShoppingOpened?.Invoke();
            }
            else
            {
                if (playSoundEffects && IsInteractable)
                {
                    SoundEffectsManager.Instance.PlayCloseWindow();
                }

                _canvasGroup.alpha = 0;
                _canvasGroup.interactable = false;
                _canvasGroup.blocksRaycasts = false;
                ShoppingClosed?.Invoke();
            }
        }

        public void DisplayShop(bool display, Inventory shopkeeperInventory, Inventory playerInventory)
        {
            DisplayShop(display);
            _shopkeeperInventory = shopkeeperInventory;
            _playerInventory = playerInventory;
            UpdateInventoryContent();
        }

        public void UpdateInventoryContent()
        {
            CleanShopkeeperInventoryContainer();

            foreach (Item item in _shopkeeperInventory.Items)
            {
                ShopShopkeeperInventorySlot shopkeeperInventorySlot = Instantiate(_shopkeeperInventorySlot, _shopkeeperInventoryContainer);
                shopkeeperInventorySlot.Init(item, _playerInventory, _shopkeeperInventory, this);
            }

            _shopkeeperMoney.SetText(_shopkeeperInventory.Money.ToString());

            CleanPlayerInventoryContainer();

            foreach (Item item in _playerInventory.Items)
            {
                ShopPlayerInventorySlot playerInventorySlot = Instantiate(_playerInventorySlot, _playerInventoryContainer);
                playerInventorySlot.Init(item, _playerInventory, _shopkeeperInventory, this);
            }

            _playerMoney.SetText(_playerInventory.Money.ToString());
        }

        private void CleanShopkeeperInventoryContainer()
        {
            foreach (RectTransform slot in _shopkeeperInventoryContainer)
            {
                Destroy(slot.gameObject);
            }
        }

        private void CleanPlayerInventoryContainer()
        {
            foreach (RectTransform slot in _playerInventoryContainer)
            {
                Destroy(slot.gameObject);
            }
        }
    }
}
