using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CozyGame
{
    public class InventoryCanvas : Menu
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
            DisplayInventory(false, false);
        }

        private void Start()
        {
            UpdateInventoryContent();
        }

        public void CloseInventory()
        {
            DisplayInventory(false);
        }

        public void DisplayInventory(bool display, bool playSoundEffects = true)
        {
            if (display)
            {
                if (playSoundEffects)
                {
                    SoundEffectsManager.Instance.PlayOpenWindow();
                }

                UpdateInventoryContent();
                Open();
            }
            else
            {
                if (playSoundEffects)
                {
                    SoundEffectsManager.Instance.PlayCloseWindow(); 
                }

                Close();
            }
        }

        public void UpdateInventoryContent()
        {
            CleanItemsContainer();

            foreach (Item item in _inventory.Items)
            {
                InventoryItemSlot itemSlot = Instantiate(_inventorySlotPrefab, _itemsContainer);
                itemSlot.Init(item, _inventory, this);
            }

            CleanEquipmentContainer();

            foreach (EquipmentSlot slot in _inventory.EquipmentSlots)
            {
                InventoryEquipmentSlot equipmentSlot = Instantiate(_equipementSlotPrefab, _equipementContainer);
                equipmentSlot.Init(slot, _inventory, this);
            }
        }

        private void CleanItemsContainer()
        {
            foreach (RectTransform item in _itemsContainer)
            {
                Destroy(item.gameObject);
            }
        }

        private void CleanEquipmentContainer()
        {
            foreach (RectTransform equipment in _equipementContainer)
            {
                Destroy(equipment.gameObject);
            }
        }
    }
}
