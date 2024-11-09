using UnityEngine;
using UnityEngine.UI;

public abstract class ResourceView : MonoBehaviour
{
    [SerializeField] private Text _resourceBondText;
    [SerializeField] private Text _resourceCoinText;
    [SerializeField] private Text _resourceWoodText;
    [SerializeField] private Text _resourceOreText;
    [SerializeField] private Text _resourceCoalText;

    public virtual void UpdateResource(GameResources resources)
    {
        _resourceBondText.text = resources.Bonds.ToString();
        _resourceCoalText.text = resources.Coal.ToString();
        _resourceCoinText.text = resources.Coins.ToString();
        _resourceOreText.text = resources.Ore.ToString();
        _resourceWoodText.text = resources.Wood.ToString();
    }
}