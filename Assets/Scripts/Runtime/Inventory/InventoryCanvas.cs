using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CozyGame
{
    [RequireComponent(typeof(CanvasGroup))]
    public class InventoryCanvas : MonoBehaviour
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

        private CanvasGroup _canvasGroup;

        public bool IsInteractable { get => _canvasGroup.interactable; }

        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
            DisplayInventory(false, false);
        }

        private void Start()
        {
            UpdateInventoryContent();
        }

        public void Close()
        {
            DisplayInventory(false);
        }

        public void DisplayInventory(bool display, bool playSoundEffects = true)
        {
            if (display)
            {
                _canvasGroup.alpha = 1;
                _canvasGroup.interactable = true;
                _canvasGroup.blocksRaycasts = true;
                UpdateInventoryContent();

                if (playSoundEffects)
                {
                    SoundEffectsManager.Instance.PlayOpenWindow();
                }
            }
            else
            {
                _canvasGroup.alpha = 0;
                _canvasGroup.interactable = false;
                _canvasGroup.blocksRaycasts = false;

                if (playSoundEffects)
                {
                    SoundEffectsManager.Instance.PlayCloseWindow(); 
                }
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
