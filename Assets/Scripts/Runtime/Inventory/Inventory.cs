using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CozyGame
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField]
        private float _money;
        [SerializeField]
        private List<Item> _items;
        [SerializeField]
        private List<EquipmentSlot> _equipmentSlots;

        public List<Item> Items => _items;
        public List<EquipmentSlot> EquipmentSlots => _equipmentSlots;
        public float Money => _money;

        public void RemoveItem(Item item)
        {
            _items.Remove(item);
        }

        public void AddItem(Item item)
        {
            Items.Add(item);
        }

        public void AddMoney(float amount)
        {
            _money += amount;
        }

        public void RemoveMoney(float amount)
        {
            _money -= amount;
        }

        public void Equip(Item item)
        {
            EquipmentSlot equipmentSlot = GetEquipmentSlot(item.EquipmentType);

            if (equipmentSlot == null)
            {
                return;
            }

            if (equipmentSlot.Item != null)
            {
                Unequipe(equipmentSlot);
            }

            equipmentSlot.Equip(item);
            RemoveItem(item);
        }

        public void Unequipe(EquipmentSlot equipmentSlot)
        {
            AddItem(equipmentSlot.Item);
            equipmentSlot.Unequip();
        }

        private EquipmentSlot GetEquipmentSlot(EquipmentType equipmentType)
        {
            EquipmentSlot equipmentSlot = _equipmentSlots.FirstOrDefault((slot) => slot.EquipmentType == equipmentType);
            return equipmentSlot;
        }
    }
}
