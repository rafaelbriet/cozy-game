using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.U2D.Animation;

namespace CozyGame
{
    [CreateAssetMenu(fileName = nameof(Item), menuName = nameof(Item))]
    public class Item : ScriptableObject
    {
        [SerializeField]
        private string _itemName;
        [SerializeField]
        private float _price;
        [SerializeField]
        private Sprite _icon;
        [SerializeField]
        private EquipmentType _equipmentType;
        [SerializeField]
        private SpriteLibraryAsset _spriteLibrary;

        public string ItemName => _itemName;
        public float Price => _price;
        public Sprite Icon => _icon;
        public EquipmentType EquipmentType => _equipmentType;
        public SpriteLibraryAsset SpriteLibrary => _spriteLibrary;
    }
}
