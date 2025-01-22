using MyUnity.Utilities;
using UnityEngine;

public class DialogueOnClick : MonoBehaviour
{
    [SerializeField] DialogueManager _dialogueSystem;
    [SerializeField] GameObject _dialogueCanvas;
    void Start() =>
        _dialogueSystem =
        GameObject.FindGameObjectWithTag("DialogueManager").GetComponent<DialogueManager>();
    public void Perform()
    {
        _dialogueSystem.DisplayNextSentence();

        if(_dialogueSystem.isSceneEnding) _dialogueCanvas.SetActive(false);
    }
}
