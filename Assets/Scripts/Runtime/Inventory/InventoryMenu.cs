using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CozyGame
{
    public class InventoryMenu : Menu
    {
        [SerializeField]
        private Inventory _inventory;
        [SerializeField]
        private RectTransform _itemsContainer;
        [SerializeField]
        private InventoryItemSlot _inventorySlotPrefab;
        [SerializeField]
        private RectTransform _equipementContainer;
        [SerializeField]
        private InventoryEquipmentSlot _equipementSlotPrefab;

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

        public void UpdateInventoryContent()
        {
            _itemsContainer.DestroyAllChildren();

            foreach (Item item in _inventory.Items)
            {
                InventoryItemSlot itemSlot = Instantiate(_inventorySlotPrefab, _itemsContainer);
                itemSlot.Init(item, _inventory, this);
            }

            _equipementContainer.DestroyAllChildren();

            foreach (EquipmentSlot slot in _inventory.EquipmentSlots)
            {
                InventoryEquipmentSlot equipmentSlot = Instantiate(_equipementSlotPrefab, _equipementContainer);
                equipmentSlot.Init(slot, _inventory, this);
            }
        }
    }
}
