using UnityEngine;

public class ColorGameManager : MonoBehaviour
{
    public GameColors[] colorArray;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

[System.Serializable]
public struct GameColors
{
     public string colorName;
     public Color color;

    public GameColors(string name, Color c)
    {
        colorName = name;
        color = c;
    }
}