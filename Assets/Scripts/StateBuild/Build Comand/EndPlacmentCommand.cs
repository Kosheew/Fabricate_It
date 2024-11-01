using Buildings;
using UnityEngine;
namespace CommandBuild.Build
{
    public class EndPlacmentCommand : Command
    {
        private BuildingContext _context;

        public EndPlacmentCommand(BuildingContext context)
        {
            _context = context;
        }

        public override void Execute()
        {
            _context.MoveBuildState?.Exit(_context);
            Debug.Log("Execute command Move");
        }
    }
}