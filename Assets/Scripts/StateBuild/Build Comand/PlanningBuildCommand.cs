using Buildings;
using UnityEngine;
namespace Command.Build
{
    public class PlanningBuildCommand : ICommand
    {
        private BuildingContext _context;

        public PlanningBuildCommand(BuildingContext context)
        {
            _context = context;
        }

        public void Execute()
        {
            _context.TransitionToState(_context.PlanningBuildState);
            Debug.Log("Execute command Move");
        }
    }
}