using Buildings;
using Managers;
using UnityEngine;


namespace CommandBuild.Build
{
    public class BuildBuy : Command
    {
        private BuildingContext _context;
        private ResourcesManager _resourcesManager;
        private BuildingStateFactory _stateFactory;
        private StateManager _stateManager;

        public BuildBuy(BuildingContext context, DependencyContainer container)
        {
            _context = context; 
            _resourcesManager = container.Resolve<ResourcesManager>();
            _stateFactory = container.Resolve<BuildingStateFactory>();
            _stateManager = container.Resolve<StateManager>();
        }

        public override void Execute()
        {
            if (!_context.BuildData.Bought)
            {
                var resourcesInfo = _context.GetResourcesUpgrade();

                if (_resourcesManager.HasEnoughResources(resourcesInfo))
                {
                    _resourcesManager.SubtractResources(resourcesInfo);

                    _context.BuildData.Bought = true;

                    Debug.Log("Buy Build");

                    _stateManager.EndPurchase(_context);
                    _stateManager.SetState(_stateFactory.CreateState(BuildingStateType.UnderConstruction), _context);

                 //   _context.PlanningBuildState.Exit(_context);
                  //  _context.TransitionToState(_context.UnderConstructionState);
                }
            }
        }
    }
}