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

    // Додавання ресурсів (окремий тип ресурсу)
    public void AddResource(ResourceType type, int amount)
    {
        if (_resources.TryGetValue(type, out var resource))
        {
            resource.Add(amount);
            UpdateView();
        }
    }

    // Додавання ресурсів (список ресурсів)
    public void AddResources(List<IResource> resources)
    {
        foreach (var resource in resources)
        {
            AddResource(resource.Type, resource.Amount);
        }
    }

    // Віднімання ресурсів (окремий тип ресурсу)
    public void SubtractResource(ResourceType type, int amount)
    {
        if (_resources.TryGetValue(type, out var resource) && resource.HasEnough(amount))
        {
            resource.Subtract(amount);
            UpdateView();
        }
        else
        {
            Debug.LogWarning($"Недостатньо {type} для виконання операції.");
        }
    }

    // Віднімання ресурсів (список ресурсів)
    public void SubtractResources(List<IResource> resources)
    {
        if (HasEnoughResources(resources))
        {
            foreach (var resource in resources)
            {
                SubtractResource(resource.Type, resource.Amount);
            }
            UpdateView();
        }
        else
        {
            Debug.LogWarning("Не вистачає ресурсів для виконання операції.");
        }
    }

    // Перевірка достатньої кількості ресурсів для списку
    public bool HasEnoughResources(List<IResource> resources)
    {
        foreach (var resource in resources)
        {
            if (!_resources.TryGetValue(resource.Type, out var availableResource) || !availableResource.HasEnough(resource.Amount))
            {
                return false;
            }
        }
        return true;
    }

    public bool HasEnoughResource(ResourceType type, int amount)
    {
        if (_resources.TryGetValue(type, out var resource))
        {
            return resource.HasEnough(amount);
        }
        Debug.LogWarning($"Ресурс {type} не знайдено.");
        return false;
    }


    // Оновлення інтерфейсу після змін ресурсів
    private void UpdateView()
    {
        _view.UpdateResource(_resources.Values);
    }
}
