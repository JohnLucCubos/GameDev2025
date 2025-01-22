using UnityEngine;
namespace player.controls
{
    [RequireComponent(typeof(Collider2D))]
    public class PlayerInteraction : MonoBehaviour, IInteractable
    {
        IInteractable _objectTriggered;
        void OnTriggerEnter2D(Collider2D _origin)
        {
            _origin.TryGetComponent(out IInteractable _iinteractable);
            if (_iinteractable != null) _objectTriggered = _iinteractable;
        }
        void OnTriggerExit2D(Collider2D _origin)
        {
            _objectTriggered = null;
        }
        public void Interactable() => _objectTriggered?.Interactable();
    }
}