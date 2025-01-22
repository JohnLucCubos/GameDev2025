using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class NPCInteraction : MonoBehaviour, IInteractable
{

    [SerializeField] Collider2D interactionZone;
    [SerializeField] bool isPlayerNear;

    void Start() => interactionZone = this.gameObject.GetComponent<Collider2D>();
    void OnTriggerEnter2D(Collider2D interactable) => isPlayerNear = interactable.tag == "Player" ? true : false;

    void OnTriggerExit2D(Collider2D interactable) => isPlayerNear = false;

    public void Interactable()
    {
        if (!isPlayerNear) return;

        Debug.Log($"{gameObject.name} was interacted!");
    }
}
