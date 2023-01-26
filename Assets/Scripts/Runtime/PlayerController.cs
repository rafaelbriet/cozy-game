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
        private InventoryMenu _inventoryCanvas;
        [SerializeField]
        private ShoppingMenu _shoppingCanvas;
        [SerializeField]
        private AudioClip[] _footstepsSoundEffect;
        [SerializeField]
        private AudioSource _audioSource;
        [SerializeField]
        private PauseMenu _pauseMenu;
        [SerializeField]
        private DialogMenu _dialogCanvas;

        private PlayerInput _playerInput;
        private Rigidbody2D _rigidbody2D;
        private Vector2 _moveDirection;
        private bool _isInsideShopTrigger;
        private Inventory _shopkeeprInventory;
        private DialogPlayer _dialogPlayer;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _playerInput = GetComponent<PlayerInput>();
        }

        private void OnEnable()
        {
            _inventoryCanvas.Opened += OnUIOpened;
            _inventoryCanvas.Closed += OnUIClosed;
            _shoppingCanvas.Opened += OnUIOpened;
            _shoppingCanvas.Closed += OnUIClosed;
            _pauseMenu.Opened += OnPauseMenuOpened;
            _pauseMenu.Closed += OnPauseMenuClosed;
        }

        private void OnDisable()
        {
            _inventoryCanvas.Opened -= OnUIOpened;
            _inventoryCanvas.Closed -= OnUIClosed;
            _shoppingCanvas.Opened -= OnUIOpened;
            _shoppingCanvas.Closed -= OnUIClosed;
            _pauseMenu.Opened -= OnPauseMenuOpened;
            _pauseMenu.Closed -= OnPauseMenuClosed;
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

            if (collision.CompareTag("DialogTrigger"))
            {
                _dialogPlayer = collision.GetComponent<DialogPlayer>();
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("ShopTrigger"))
            {
                _isInsideShopTrigger = false;
                _shopkeeprInventory = null;
            }

            if (collision.CompareTag("DialogTrigger"))
            {
                _dialogPlayer = null;
                _dialogCanvas.Close();
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

            if (_inventoryCanvas.IsInteractable)
            {
                _inventoryCanvas.Close();
            }
            else
            {
                _inventoryCanvas.Open();
            }
            
        }

        public void OnInteract()
        {
            OpenDialog();
        }

        private void OpenDialog()
        {
            if (_dialogCanvas == null || _dialogPlayer == null)
            {
                Debug.Log("Dialog is not available.", this);
                return;
            }

            if (_shopkeeprInventory != null)
            {
                _dialogCanvas.SetDialog(_dialogPlayer, () => OpenShopping());
            }
            else
            {
                _dialogCanvas.SetDialog(_dialogPlayer);
            }

            _dialogCanvas.Open();
        }

        private void OpenShopping()
        {
            if (_shoppingCanvas == null)
            {
                Debug.Log("Shop is not available.", this);
                return;
            }

            if (_isInsideShopTrigger && !_shoppingCanvas.IsInteractable)
            {
                _shoppingCanvas.SetUpShop(_shopkeeprInventory, _inventory);
                _shoppingCanvas.Open();
            }
        }

        public void OnClose()
        {
            _shoppingCanvas.Close();
            _inventoryCanvas.Close();
        }

        public void OnPause()
        {
            if (_pauseMenu == null)
            {
                Debug.Log("Cannot pause now.", this);
                return;
            }

            _pauseMenu.Open();
        }

        public void OnUnpause()
        {
            if (_pauseMenu == null)
            {
                Debug.LogError("Cannot unpause.", this);
                return;
            }

            _pauseMenu.Close();
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
            _playerInput.SwitchCurrentActionMap("Inventory");
        }

        private void OnPauseMenuOpened()
        {
            _playerInput.SwitchCurrentActionMap("Pause");
        }

        private void OnPauseMenuClosed()
        {
            _playerInput.SwitchCurrentActionMap("Gameplay");
        }
    }
}
