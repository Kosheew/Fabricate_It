using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceView : MonoBehaviour
{
    [SerializeField] private Text _resourceBondText;
    [SerializeField] private Text _resourceCoinText;
    [SerializeField] private Text _resourceWoodText;
    [SerializeField] private Text _resourceOreText;
    [SerializeField] private Text _resourceCoalText;

    private Dictionary<ResourceType, Text> _resourceTexts;

    public void Init()
    {
        _resourceTexts = new Dictionary<ResourceType, Text>
        {
            { ResourceType.Bond, _resourceBondText },
            { ResourceType.Coin, _resourceCoinText },
            { ResourceType.Wood, _resourceWoodText },
            { ResourceType.Ore, _resourceOreText },
            { ResourceType.Coal, _resourceCoalText }
        };
    }

    public void UpdateResource(Dictionary<ResourceType, IResource> resources)
    {
        foreach (var resource in resources)
        {
            if (_resourceTexts.ContainsKey(resource.Key))
            {
                _resourceTexts[resource.Key].text = resource.Value.Amount.ToString();
            }
        }
    }
}
