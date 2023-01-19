using System.Collections.Generic;
using UnityEngine;

namespace CozyGame
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField]
        private List<Item> _items;

        public List<Item> Items => _items;
    }
}
