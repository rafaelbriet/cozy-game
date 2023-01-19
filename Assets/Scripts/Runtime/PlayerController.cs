using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CozyGame
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private float _walkSpeed = 5.0f;
        [SerializeField]
        private Animator _animator;

        private Rigidbody2D _rigidbody2D;
        private Vector2 _moveDirection;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            Vector2 movePosition = (_moveDirection * _walkSpeed * Time.fixedDeltaTime) + _rigidbody2D.position;
            _rigidbody2D.MovePosition(movePosition);
        }

        public void OnMove(InputValue value)
        {
            _moveDirection = value.Get<Vector2>();

            if (_moveDirection != Vector2.zero)
            {
                _animator.SetFloat("Horizontal", _moveDirection.x);
                _animator.SetFloat("Vertical", _moveDirection.y);
                _animator.SetBool("IsWalking", true);
            }
            else
            {
                _animator.SetBool("IsWalking", false);
            }
        }
    }
}
