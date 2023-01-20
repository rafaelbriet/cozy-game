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

        public void Init(Item item)
        {
            _itemIcon.sprite = item.Icon;
            _itemName.SetText(item.ItemName);
        }
    }
}
