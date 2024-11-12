using Buildings;
using System.Resources;

namespace CommandBuild.Build
{
    public class BuildBuy : Command
    {
        private BuildingContext _context;
        private ResourcesManager _resourcesManager;
        
        public BuildBuy(BuildingContext context, ResourcesManager resourcesManager)
        {
            _context = context; 
            _resourcesManager = resourcesManager;
        }

        public override void Execute()
        {
            if (!_context.BuildData.Bought)
            {
                var resourcesInfo = _context.BuildSettings.LeveResources[_context.BuildLevel].UpgradeResources.ToResourceList();

                if (_resourcesManager.HasEnoughResources(resourcesInfo))
                {
                    _resourcesManager.SubtractResources(resourcesInfo);


                    _context.BuildData.Bought = true;
                    _context.PlanningBuildState.Exit(_context);
                    _context.TransitionToState(_context.UnderConstructionState);
                }
            }
        }
    }
}