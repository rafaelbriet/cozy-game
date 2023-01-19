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

        public void Init(Item item)
        {
            _itemName.SetText(item.ItemName);
            _itemIcon.sprite = item.Icon;
        }
    }
}
