using Buildings;
using Managers;
using UnityEngine;
namespace CommandBuild.Build
{
    public class StartPlacmentCommand : Command
    {
        private BuildingContext _context;
        private StateManager _stateManager;

        public StartPlacmentCommand(BuildingContext context, DependencyContainer container)
        {
            _context = context;
            _stateManager = container.Resolve<StateManager>();
        }

        public override void Execute()
        {
           // _stateManager.StartPurchaseWithMove(_context);
        }
    }
}