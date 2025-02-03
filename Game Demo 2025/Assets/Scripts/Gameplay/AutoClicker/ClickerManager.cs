using UnityEngine;
using TMPro;

public class ClickerManager : MonoBehaviour
{
    [SerializeField] TMP_Text _score;
    [SerializeField] int _totalValue = 0;

    public void AddValue(int value)
    {
        _totalValue += value;
        _score.text = $"{_totalValue}";
    }
}
