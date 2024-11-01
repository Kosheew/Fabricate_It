using Buildings;
using UnityEngine;
namespace CommandBuild.Build
{
    public class PlanningBuildCommand : Command
    {
        private BuildingContext _context;

        public PlanningBuildCommand(BuildingContext context)
        {
            _context = context;
        }

        public override void Execute()
        {
            _context.TransitionToState(_context.PlanningBuildState);
            Debug.Log("Execute command Move");
        }
    }
}