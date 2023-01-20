using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

namespace CozyGame
{
    public class ShopPlayerInventorySlot : MonoBehaviour
    {
        [SerializeField]
        private Image _itemIcon;
        [SerializeField]
        private TextMeshProUGUI _itemName;
        [SerializeField]
        private TextMeshProUGUI _itemPrice;

        private Item _item;
        private Inventory _playerIventory;
        private Inventory _shopkeeperInventory;
        private ShoppingCanvas _shoopingCanvas;

        public void Init(Item item, Inventory playerInventory, Inventory shopkeeperInventory, ShoppingCanvas shoppingCanvas)
        {
            _item = item;
            _playerIventory = playerInventory;
            _shopkeeperInventory = shopkeeperInventory;
            _shoopingCanvas = shoppingCanvas;
            _itemIcon.sprite = item.Icon;
            _itemName.SetText(item.ItemName);
            _itemPrice.SetText(item.Price.ToString());
        }

        public void Sell()
        {
            _playerIventory.RemoveItem(_item);
            _shopkeeperInventory.AddItem(_item);
            _shoopingCanvas.UpdateInventoryContent();
        }
    }
}
