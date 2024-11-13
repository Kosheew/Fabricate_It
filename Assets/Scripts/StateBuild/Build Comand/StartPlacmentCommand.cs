using Buildings;
using Managers;
using UnityEngine;
namespace CommandBuild.Build
{
    public class StartPlacmentCommand : Command
    {
        private BuildingContext _context;
        private IBuildingStateFactory _buildFactory;
        private StateManager _stateManager;

        public StartPlacmentCommand(BuildingContext context, IBuildingStateFactory buildFactory, StateManager stateManager)
        {
            _context = context;
            _buildFactory = buildFactory;
            _stateManager = stateManager;
        }

        public override void Execute()
        {
            _stateManager.SetMove(_buildFactory.CreateState(BuildingStateType.Move), _context);
        }
    }
}