using UnityEngine;
using Buildings;
using BuildingState;
/// <summary>
/// Команда для апгрейду будівлі.
/// </summary>
namespace CommandBuild.Build
{
    public class UpgradeCommand : Command
    {
        private BuildingContext _context;
        private ResourcesManager _resourcesManager;
        public UpgradeCommand(BuildingContext context, ResourcesManager resourcesManager)
        {
            _context = context;
            _resourcesManager = resourcesManager;
        }

        public override void Execute()
        {
            //if (_context.CurrentState is BuiltState)
            //{
            //    var resourcesInfo = _context.GetResourcesUpgrade();
                
            //    if (_resourcesManager.HasEnoughResources(resourcesInfo))
            //    {
            //        _resourcesManager.SubtractResources(resourcesInfo);
            //       // _context.TransitionToState(_context.UnderConstructionState);
            //    }
            //}
        }
    }
}