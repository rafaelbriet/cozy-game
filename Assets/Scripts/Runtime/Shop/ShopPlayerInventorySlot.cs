using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
        private ShoppingMenu _shoopingCanvas;

        public void Init(Item item, Inventory playerInventory, Inventory shopkeeperInventory, ShoppingMenu shoppingCanvas)
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
            if (_shopkeeperInventory.Money < _item.Price)
            {
                Debug.Log("Shopkepper don't have enough money.", _shopkeeperInventory.gameObject);
                return;
            }

            _playerIventory.RemoveItem(_item);
            _playerIventory.AddMoney(_item.Price);
            _shopkeeperInventory.AddItem(_item);
            _shopkeeperInventory.RemoveMoney(_item.Price);
            _shoopingCanvas.UpdateInventoryContent();
            SoundEffectsManager.Instance.PlaySellItem();
        }

        public void OnPointEnter()
        {
            SoundEffectsManager.Instance.PlayButtonHover();
        }
    }
}
