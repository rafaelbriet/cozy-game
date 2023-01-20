using UnityEngine;

namespace CozyGame
{
    [RequireComponent(typeof(AudioSource))]
    public class SoundEffectsManager : MonoBehaviour
    {
        public static SoundEffectsManager Instance;

        [SerializeField]
        private AudioClip _buttonHover;
        [SerializeField]
        private AudioClip _openWindow;
        [SerializeField]
        private AudioClip _closeWindow;
        [SerializeField]
        private AudioClip _equipItem;
        [SerializeField]
        private AudioClip _unequipItem;
        [SerializeField]
        private AudioClip _sellItem;
        [SerializeField]
        private AudioClip _buyItem;
        [SerializeField]
        private AudioClip _cancel;
        [SerializeField]
        private AudioClip _paused;
        [SerializeField]
        private AudioClip _unpaused;

        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            Instance = this;
        }

        public void PlayButtonHover()
        {
            _audioSource.PlayOneShot(_buttonHover);
        }

        public void PlayOpenWindow()
        {
            _audioSource.PlayOneShot(_openWindow);
        }

        public void PlayCloseWindow()
        {
            _audioSource.PlayOneShot(_closeWindow);
        }

        public void PlayEquipItem()
        {
            _audioSource.PlayOneShot(_equipItem);
        }

        public void PlayUnequipItem()
        {
            _audioSource.PlayOneShot(_unequipItem);
        }

        public void PlaySellItem()
        {
            _audioSource.PlayOneShot(_sellItem);
        }

        public void PlayBuyItem()
        {
            _audioSource.PlayOneShot(_buyItem);
        }

        public void PlayCancel()
        {
            _audioSource.PlayOneShot(_cancel);
        }

        public void PlayPaused()
        {
            _audioSource.PlayOneShot(_paused);
        }

        public void PlayUnpause()
        {
            _audioSource.PlayOneShot(_unpaused);
        }
    }
}
