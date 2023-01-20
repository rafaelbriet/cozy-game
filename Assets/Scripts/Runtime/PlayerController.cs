using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CozyGame
{
    [RequireComponent(typeof(Rigidbody2D), typeof(PlayerInput))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private float _walkSpeed = 5.0f;
        [SerializeField]
        private Inventory _inventory;
        [SerializeField]
        private Animator _animator;
        [SerializeField]
        private InventoryCanvas _inventoryCanvas;
        [SerializeField]
        private ShoppingCanvas _shoppingCanvas;
        [SerializeField]
        private AudioClip[] _footstepsSoundEffect;
        [SerializeField]
        private AudioSource _audioSource;

        private PlayerInput _playerInput;
        private Rigidbody2D _rigidbody2D;
        private Vector2 _moveDirection;
        private bool _isInsideShopTrigger;
        private Inventory _shopkeeprInventory;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _playerInput = GetComponent<PlayerInput>();
        }

        private void OnEnable()
        {
            _inventoryCanvas.InventoryOpened += OnUIOpened;
            _shoppingCanvas.ShoppingOpened += OnUIOpened;
            _inventoryCanvas.InventoryClosed += OnUIClosed;
            _shoppingCanvas.ShoppingClosed += OnUIClosed;
        }

        private void OnDisable()
        {
            _inventoryCanvas.InventoryOpened -= OnUIOpened;
            _shoppingCanvas.ShoppingOpened -= OnUIOpened;
            _inventoryCanvas.InventoryClosed -= OnUIClosed;
            _shoppingCanvas.ShoppingClosed -= OnUIClosed;
        }

        private void FixedUpdate()
        {
            Vector2 movePosition = (_moveDirection * _walkSpeed * Time.fixedDeltaTime) + _rigidbody2D.position;
            _rigidbody2D.MovePosition(movePosition);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("ShopTrigger"))
            {
                _isInsideShopTrigger = true;
                _shopkeeprInventory = collision.GetComponentInParent<Inventory>();
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("ShopTrigger"))
            {
                _isInsideShopTrigger = false;
                _shoppingCanvas.DisplayShop(false);
                _shopkeeprInventory = null;
            }
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

        public void OnInventory()
        {
            if (_inventoryCanvas == null)
            {
                Debug.Log("Inventory is not available.", this);
                return;
            }

            _inventoryCanvas.DisplayInventory(!_inventoryCanvas.IsInteractable);
        }

        public void OnInteract()
        {
            if (_shoppingCanvas == null)
            {
                Debug.Log("Shop is not available.", this);
                return;
            }

            if (_isInsideShopTrigger && !_shoppingCanvas.IsInteractable)
            {
                _shoppingCanvas.DisplayShop(true, _shopkeeprInventory, _inventory);
            }
        }

        public void OnClose()
        {
            _shoppingCanvas.DisplayShop(false);
            _inventoryCanvas.DisplayInventory(false);
        }

        public void PlayFootstep()
        {
            AudioClip clip = _footstepsSoundEffect[Random.Range(0, _footstepsSoundEffect.Length)];
            _audioSource.PlayOneShot(clip);
        }

        private void OnUIClosed()
        {
            _playerInput.SwitchCurrentActionMap("Gameplay");
        }

        private void OnUIOpened()
        {
            _playerInput.SwitchCurrentActionMap("UI");
        }
    }
}
