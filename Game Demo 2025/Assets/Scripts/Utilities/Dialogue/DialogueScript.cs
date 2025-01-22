using UnityEngine;
// fix to acomodate for new Dialogue system
[CreateAssetMenu(fileName = "Script", menuName = "Dialogue/Script", order = 0)]
public class DialogueScript : ScriptableObject 
{
    public Dialogue[] dialogue;
}