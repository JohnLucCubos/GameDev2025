using UnityEngine;

namespace player.controls
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour, IMovement
    {
        private Rigidbody2D _rb2d;
        [Header("Movement attributes")]
        [SerializeField] float _speed;
        [SerializeField] float _bonusSpeed;

        public Vector2 getDirection { get; private set; }
        public float speed { get => _speed; set { _speed = value; } }
        public float bonusSpeed { get => _bonusSpeed; set { _bonusSpeed = value; } }

        private void Awake() => _rb2d = gameObject.GetComponent<Rigidbody2D>();
        
        public void Move(Vector2 direction)
        {
            getDirection = direction;

            var _finalSpeed = _speed * _bonusSpeed;

            _rb2d.linearVelocity = direction * _finalSpeed;
        }
    }
}