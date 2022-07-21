using System;
using TMPro;
using UnityEngine;

public class MineResourcesCreation : MonoBehaviour
{
    [SerializeField] private float _timeBetweenOreSpawn;

    [SerializeField] private int _amountOfOre;

    public event Action<int> OreAmmountChanged;
    
    private float _currentTime;

    private void FixedUpdate()
    {
        _currentTime += Time.fixedDeltaTime;
        if (_currentTime >= _timeBetweenOreSpawn)
        {
            _amountOfOre++;
            _currentTime = 0;
            OreAmmountChanged?.Invoke(_amountOfOre);
        }
        
    }
}
