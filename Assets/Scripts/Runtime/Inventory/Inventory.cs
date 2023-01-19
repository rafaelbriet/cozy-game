using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CozyGame
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField]
        private List<Item> _items;
        [SerializeField]
        private List<EquipmentSlot> _equipmentSlots;

        public List<Item> Items => _items;

        public void RemoveItem(Item item)
        {
            _items.Remove(item);
        }

        public void Equip(Item item)
        {
            EquipmentSlot equipmentSlot = GetEquipmentSlot(item.EquipmentType);

            if (equipmentSlot != null)
            {
                equipmentSlot.Equip(item);
                RemoveItem(item);
            }
        }

        private EquipmentSlot GetEquipmentSlot(EquipmentType equipmentType)
        {
            EquipmentSlot equipmentSlot = _equipmentSlots.FirstOrDefault((slot) => slot.EquipmentType == equipmentType);
            return equipmentSlot;
        }
    }
}
