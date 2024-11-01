using UnityEngine;

public class ResourcesManager : MonoBehaviour
{
    private GameResources _gameResources;
    private ResourceView _view;

    public void Init(GameResources gameResources, ResourceView view)
    {
        _gameResources = gameResources;
        _view = view;
    }

    public void SubCoins(int value)
    {
        _gameResources.Coins -= value;
        _view.UpdateResouce(_gameResources.Coins);
    }   
}