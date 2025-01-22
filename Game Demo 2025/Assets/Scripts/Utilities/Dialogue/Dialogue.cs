using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue", menuName = "Dialogue/empty", order = 0)]
public class Dialogue : ScriptableObject
{
    public string characterName;
    public Sprite characterSprite;
    [TextArea(1,5)] public string sentences;
    public string audioSFX;
}