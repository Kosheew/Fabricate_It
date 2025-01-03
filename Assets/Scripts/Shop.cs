using Buildings;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private GameObject _panelShop;
    [SerializeField] private BuildingContext[] _buildingsContext;

    private CommandBuildFabric _commandFabric;

    private GameData _gameData;

    public void Init(DependencyContainer container)
    {
        _commandFabric = container.Resolve<CommandBuildFabric>();
        _gameData = container.Resolve<GameData>();
    }

    public void ChooseBuild()
    {
        if (!_gameData.BuildsData[0].Bought)
        {
            _commandFabric.SetBuild(_buildingsContext[0]);
            _commandFabric.CreatePlanningBuildCommand(_buildingsContext[0]);
            _panelShop.SetActive(false);
        }
    }  
}
