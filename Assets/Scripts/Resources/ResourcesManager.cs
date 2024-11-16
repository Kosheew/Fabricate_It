using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

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

    public void ChangeReputation(int value)
    {
        _gameResources.Reputation += value;

        if(_gameResources.Reputation > 100)
            _gameResources.Reputation = 100;

        if (_gameResources.Reputation < -100)
            _gameResources.Reputation = -100;

        _view.UpdateResouce(_gameResources.Reputation);
    }
}