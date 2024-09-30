using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameView : MonoBehaviour
{
    [SerializeField] private Text _bondsText;
    [SerializeField] private Text _coinsText;


    public void UpdateCoins(int value)
    {
        _coinsText.text = $"Coins: {value}";
    }

    public void UpdateBonds(int value)
    {
        _bondsText.text = $"Bonds: {value}";
    }
}
