using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceView : MonoBehaviour
{
    [SerializeField] private Text _bondsText;
    [SerializeField] private Text _coinsText;
    [SerializeField] private Text _coalText;
    [SerializeField] private Text _oreText;
    [SerializeField] private Text _treeText;

    public void UpdateCoins(int value)
    {
        _coinsText.text = $"{value}";
    }

    public void UpdateBonds(int value)
    {
        _bondsText.text = $"{value}";
    }

    public void UpdateCoal(int value)
    {
        _coalText.text = $"{value}";
    }
    public void UpdateOre(int value)
    {
        _oreText.text = $"{value}";
    }
    public void UpdateTree(int value)
    {
        _treeText.text = $"{value}";
    }
}
