using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace CozyGame
{
    public class ShoppingMenu : Menu
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

        private Inventory _shopkeeperInventory;
        private Inventory _playerInventory;

        protected override void Awake()
        {
            base.Awake();
            base.Close();
        }

        public override void Open()
        {
            SoundEffectsManager.Instance.PlayOpenWindow();
            UpdateInventoryContent();
            base.Open();
        }

        public override void Close()
        {
            SoundEffectsManager.Instance.PlayCloseWindow();
            base.Close();
        }

        public void SetUpShop(Inventory shopkeeperInventory, Inventory playerInventory)
        {
            _shopkeeperInventory = shopkeeperInventory;
            _playerInventory = playerInventory;
        }

        public void UpdateInventoryContent()
        {
            _shopkeeperMoney.SetText(_shopkeeperInventory.Money.ToString());
            _shopkeeperInventoryContainer.DestroyAllChildren();

            foreach (Item item in _shopkeeperInventory.Items)
            {
                ShopShopkeeperInventorySlot shopkeeperInventorySlot = Instantiate(_shopkeeperInventorySlot, _shopkeeperInventoryContainer);
                shopkeeperInventorySlot.Init(item, _playerInventory, _shopkeeperInventory, this);
            }

            _playerMoney.SetText(_playerInventory.Money.ToString());
            _playerInventoryContainer.DestroyAllChildren();

            foreach (Item item in _playerInventory.Items)
            {
                ShopPlayerInventorySlot playerInventorySlot = Instantiate(_playerInventorySlot, _playerInventoryContainer);
                playerInventorySlot.Init(item, _playerInventory, _shopkeeperInventory, this);
            }
        }
    }
}
