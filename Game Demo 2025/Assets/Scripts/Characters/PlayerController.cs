using UnityEngine;
namespace player.controls
{
    public class PlayerController : MonoBehaviour
    {
        private UserControls _userControls;
        // ===== Player Interfaces =====
        private IMovement _movement;
        private IInteractable _interactable;

        void Awake()
        {
            _userControls = new UserControls();
            _userControls.Enable();

            this.gameObject.TryGetComponent(out IMovement _imovement);
            this.gameObject.TryGetComponent(out IInteractable _iinteractable);

            if(_imovement != null) _movement = _imovement;
            if(_iinteractable != null) _interactable = _iinteractable;
        }

        void Start()
        {
            // Movement
            _userControls.Player.Move.performed += ctx => _movement.Move(ctx.ReadValue<Vector2>());
            _userControls.Player.Move.canceled  += ctx => _movement.Move(Vector2.zero);
            // Interaction
            _userControls.Player.Interact.started += ctx => _interactable.Interactable();
        }

        void OnEnable() => _userControls.Enable();
        void OnDisable() => _userControls.Disable();
        void OnDestroy() => _userControls.Dispose();
    }
}