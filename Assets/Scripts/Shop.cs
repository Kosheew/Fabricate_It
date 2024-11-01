using Buildings;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private GameObject _panelShop;
    [SerializeField] private BuildingContext[] _buildingsContext;

    private CommandBuildFabric _commandFabric;

    public void Init(CommandBuildFabric commandFabric)
    {
        _commandFabric = commandFabric;
    }

    public void ChooseBuild()
    {
        _commandFabric.SetBuild(_buildingsContext[0]);
        _commandFabric.CreatePlanningBuildCommand(_buildingsContext[0]);
        _panelShop.SetActive(false);
    }  
}
