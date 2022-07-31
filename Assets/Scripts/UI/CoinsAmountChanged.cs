using System;
using TMPro;
using UnityEngine;

public class CoinsAmountChanged : MonoBehaviour
{
    [SerializeField] private Player _player;

    [SerializeField] private TMP_Text _coinsValue;

    private void OnEnable()
    {
        _player.ChangeCoinsAmount += ChangeCoinsText;
    }
    private void OnDisable()
    {
        _player.ChangeCoinsAmount += ChangeCoinsText;
    }

    private void ChangeCoinsText(int value)
    {
        _coinsValue.text = "Coins: " + value;
    }
}
