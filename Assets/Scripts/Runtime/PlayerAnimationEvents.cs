using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CozyGame
{
    public class PlayerAnimationEvents : MonoBehaviour
    {
        [SerializeField]
        private PlayerController _playerContoller;

        public void PlayFootstepSoundEffects()
        {
            if (_playerContoller == null)
            {
                return;
            }

            _playerContoller.PlayFootstep();
        }
    }
}
