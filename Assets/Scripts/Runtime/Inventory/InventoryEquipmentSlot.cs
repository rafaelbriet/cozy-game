using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CozyGame
{
    public class InventoryEquipmentSlot : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _itemName;
        [SerializeField]
        private TextMeshProUGUI _equipementType;
        [SerializeField]
        private Image _itemIcon;

        private EquipmentSlot _equipmentSlot;
        private Inventory _inventory;
        private InventoryCanvas _inventoryCanvas;

        public void Init(EquipmentSlot equipmentSlot, Inventory inventory, InventoryCanvas inventoryCanvas)
        {
            _equipmentSlot = equipmentSlot;
            _inventory = inventory;
            _inventoryCanvas = inventoryCanvas;

            if (equipmentSlot.Item == null)
            {
                _equipementType.SetText(_equipmentSlot.EquipmentType.ToString());
                _equipementType.gameObject.SetActive(true);
                _itemName.gameObject.SetActive(false);
            }
            else
            {
                _itemName.SetText(_equipmentSlot.Item.ItemName);
                _itemName.gameObject.SetActive(true);
                _equipementType.gameObject.SetActive(false);
                _itemIcon.sprite = _equipmentSlot.Item.Icon;
            }
        }
    }
}
