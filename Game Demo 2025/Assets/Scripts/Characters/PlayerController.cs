using UnityEngine;
namespace player.controls
{
    public class PlayerController : MonoBehaviour
    {
        private UserControls _userControls;
        private IMovement _movement;

        void Awake()
        {
            _userControls = new UserControls();
            _userControls.Enable();

            this.gameObject.TryGetComponent(out IMovement _imovement);

            if(_imovement != null) _movement = _imovement;
        }

        void Start()
        {
            _userControls.Player.Move.performed += ctx => _movement.Move(ctx.ReadValue<Vector2>());
            _userControls.Player.Move.canceled  += ctx => _movement.Move(Vector2.zero);
        }

        void OnEnable() => _userControls.Enable();
        void OnDisable() => _userControls.Disable();
        void OnDestroy() => _userControls.Dispose();
    }
}