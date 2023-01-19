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

        private CanvasGroup _canvasGroup;

        public bool IsInteractable { get => _canvasGroup.interactable; }

        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
            DisplayInventory(false);
        }

        private void Start()
        {
            UpdateInventoryContent();
        }

        public void DisplayInventory(bool display)
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

        public void UpdateInventoryContent()
        {
            CleanItemsContainer();

            foreach (Item item in _inventory.Items)
            {
                InventoryItemSlot itemSlot = Instantiate(_inventorySlotPrefab, _itemsContainer);
                itemSlot.Init(item, _inventory, this);
            }
        }

        private void CleanItemsContainer()
        {
            foreach (RectTransform item in _itemsContainer)
            {
                Destroy(item.gameObject);
            }
        }
    }
}
