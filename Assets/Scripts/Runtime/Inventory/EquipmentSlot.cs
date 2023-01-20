using System;
using UnityEngine;
using UnityEngine.U2D.Animation;

namespace CozyGame
{
    [RequireComponent(typeof(SpriteLibrary))]
    public class EquipmentSlot : MonoBehaviour
    {
        [SerializeField]
        private EquipmentType _equipmentType;
        [SerializeField]
        private Item _item;

        private SpriteLibrary _spriteLibrary;

        public EquipmentType EquipmentType => _equipmentType;
        public Item Item => _item;

        private void Awake()
        {
            _spriteLibrary = GetComponent<SpriteLibrary>();

            if (_item != null)
            {
                Equip(_item, false);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }

        private void OnValidate()
        {
            bool isItemValid = _item == null || _item.EquipmentType == _equipmentType;

            if (!isItemValid)
            {
                Debug.LogWarning($"Cannot equip {_item.ItemName} becase it's not the same slot type.", this);
                _item = null;
            }
        }

        public void Equip(Item item, bool playSoundEffects = true)
        {
            _item = item;
            _spriteLibrary.spriteLibraryAsset = item.SpriteLibrary;
            gameObject.SetActive(true);
            
            if (playSoundEffects)
            {
                SoundEffectsManager.Instance.PlayEquipItem(); 
            }
        }

        public void Unequip(bool playSoundEffects = true)
        {
            _item = null;
            gameObject.SetActive(false);
            
            if (playSoundEffects)
            {
                SoundEffectsManager.Instance.PlayUnequipItem(); 
            }
        }
    }
}
