using Buildings;
using Managers;
using UnityEngine;
namespace CommandBuild.Build
{
    public class PlanningBuildCommand : Command
    {
        private BuildingContext _context;
        private StateManager _stateManager;

        public PlanningBuildCommand(BuildingContext context, DependencyContainer container)
        {
            _context = context;
            _stateManager = container.Resolve<StateManager>();
        }

        public override void Execute()
        {
            _stateManager.StartPurchaseWithMove(_context);
            Debug.Log("Execute command Move");
        }
    }
}