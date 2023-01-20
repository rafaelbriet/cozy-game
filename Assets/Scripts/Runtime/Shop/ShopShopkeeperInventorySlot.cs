using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CozyGame
{
    public class ShopShopkeeperInventorySlot : MonoBehaviour
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

        public void Buy()
        {
            _shopkeeperInventory.RemoveItem(_item);
            _shopkeeperInventory.AddMoney(_item.Price);
            _playerIventory.AddItem(_item);
            _playerIventory.RemoveMoney(_item.Price);
            _shoopingCanvas.UpdateInventoryContent();
        }
    }
}
