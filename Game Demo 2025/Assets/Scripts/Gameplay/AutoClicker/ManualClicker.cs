using UnityEngine;

public class ManualClicker : MonoBehaviour
{
    [SerializeField] int value = 1;
    [SerializeField] ClickerManager manager;
    private void Start() => manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<ClickerManager>();
    public void OnClick() => manager.AddValue(value);
}
