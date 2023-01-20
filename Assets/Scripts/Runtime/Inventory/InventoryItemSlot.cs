using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CozyGame
{
    public class InventoryItemSlot : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _itemName;
        [SerializeField]
        private Image _itemIcon;

        private Item _item;
        private Inventory _inventory;
        private InventoryCanvas _inventoryCanvas;

        public void Init(Item item, Inventory inventory, InventoryCanvas inventoryCanvas)
        {
            _item = item;
            _inventory = inventory;
            _inventoryCanvas = inventoryCanvas;
            _itemName.SetText(item.ItemName);
            _itemIcon.sprite = item.Icon;
        }

        public void Equip()
        {
            _inventory.Equip(_item);
            _inventoryCanvas.UpdateInventoryContent();
        }

        public void OnPointEnter()
        {
            SoundEffectsManager.Instance.PlayButtonHover();
        }
    }
}
