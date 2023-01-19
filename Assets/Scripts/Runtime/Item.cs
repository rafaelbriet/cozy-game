using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.U2D.Animation;

namespace CozyGame
{
    [CreateAssetMenu(fileName = nameof(Item), menuName = nameof(Item))]
    public class Item : ScriptableObject
    {
        [SerializeField]
        private float _price;
        [SerializeField]
        private Sprite _icon;
        [SerializeField]
        private EquipmentSlot _equipmentSlot;
        [SerializeField]
        private SpriteLibraryAsset _spriteLibrary;

        public float Price => _price;
        public Sprite Icon => _icon;
        public EquipmentSlot EquipmentSlot => _equipmentSlot;
        public SpriteLibraryAsset SpriteLibrary => _spriteLibrary;
    }
}
