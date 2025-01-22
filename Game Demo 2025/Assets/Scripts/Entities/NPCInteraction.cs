using MyUnity.Utilities;
using UnityEngine;
namespace entity.components
{
    
[RequireComponent(typeof(Collider2D))]
public class NPCInteraction : MonoBehaviour, IInteractable
{
    [SerializeField] bool _isPlayerNear;
    [SerializeField] GameObject _dialogueCanvas;
    [SerializeField] DialogueManager _dialogueSystem;
    [SerializeField] DialogueScript _dialogueScript;
    void Start()
    {
        _dialogueSystem = GameObject.FindGameObjectWithTag("DialogueManager").GetComponent<DialogueManager>();
    }
    void OnTriggerEnter2D(Collider2D interactable) => _isPlayerNear = interactable.tag == "Player";
    void OnTriggerExit2D()
    {
        _isPlayerNear = false;
        _dialogueCanvas.SetActive(false);
    }

    public void Interactable()
    {
        if (!_isPlayerNear) return;

        _dialogueCanvas.SetActive(true);

        _dialogueSystem.DisplayDialogue(_dialogueScript);
        _dialogueSystem.DisplayNextSentence();

    }
}
}