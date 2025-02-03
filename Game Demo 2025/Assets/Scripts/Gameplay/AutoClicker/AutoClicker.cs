using System.Collections;
using UnityEngine;

public class AutoClicker : MonoBehaviour
{
    [SerializeField] int _value = 1;
    [SerializeField] float _delay = 1f;
    [SerializeField] bool _isActive;
    [SerializeField] ClickerManager manager;
    private void Start() => manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<ClickerManager>();
    public void OnClick() 
    {
        _value += 1;
        if(_isActive) return;
        StartCoroutine(AutoClick());
    }

    private IEnumerator AutoClick()
    {
        while(true)
        {
            yield return new WaitForSeconds(_delay);
            manager.AddValue(_value);
        }
    }

}
