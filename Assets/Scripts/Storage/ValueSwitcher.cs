using TMPro;
using UnityEngine;

public class ValueSwitcher : MonoBehaviour
{
    [SerializeField] private TMP_Text _valueText;
    [SerializeField] private int _currentValue;

    public int CurrentValue => _currentValue;
    
    private void ChangeValue(int value)
    {
        _currentValue += value;
        if (_currentValue < 0)
        {
            _currentValue = 0;
        }
        _valueText.text = _currentValue.ToString();
        
    }
    public void AddValue()
    {
        ChangeValue(1);
    }
    public void RemoveValue()
    {
        ChangeValue(-1);
    }
}
