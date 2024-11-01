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
            // Логіка для апгрейду будівлі
            if (_context.CurrentState is BuiltState)
            {
                Debug.Log("Upgrading the building.");
                _context.SetUpgradeFlag(true);
                _context.TransitionToState(_context.UnderConstructionState);
            }
            else
            {
                Debug.Log("Building cannot be upgraded in the current state.");
            }
        }
    }
}