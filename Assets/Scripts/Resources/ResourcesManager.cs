using System.Collections.Generic;
using UnityEngine;

public class ResourcesManager : MonoBehaviour
{
    private Dictionary<ResourceType, IResource> _resources = new Dictionary<ResourceType, IResource>();
    private ResourceView _view;

    public void Init(ResourceView view, List<IResource> resources)
    {
        _view = view;
        foreach (var resource in resources)
        {
            _resources[resource.Type] = resource;
        }
        UpdateView();
    }

    public void AddResource(ResourceType type, int amount)
    {
        if (_resources.ContainsKey(type))
        {
            _resources[type].Add(amount);
            UpdateView();
        }
    }

    public void SubtractResource(ResourceType type, int amount)
    {
        if (_resources.ContainsKey(type) && _resources[type].HasEnough(amount))
        {
            _resources[type].Subtract(amount);
            UpdateView();
        }
    }

    private void UpdateView()
    {
        _view.UpdateResource(_resources);
    }
}
