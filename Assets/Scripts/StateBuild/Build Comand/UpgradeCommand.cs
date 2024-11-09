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

        public UpgradeCommand(BuildingContext context)
        {
            _context = context;
        }

        public override void Execute()
        {
            if (_context.CurrentState is BuiltState)
            {
                _context.TransitionToState(_context.UnderConstructionState);
            }
        }
    }
}