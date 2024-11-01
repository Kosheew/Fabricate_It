using Buildings;
using UnityEngine;
namespace CommandBuild.Build
{
    public class StartPlacmentCommand : Command
    {
        private BuildingContext _context;

        public StartPlacmentCommand(BuildingContext context)
        {
            _context = context;
        }

        public override void Execute()
        {
            _context.MoveBuildState.Enter(_context);
            Debug.Log("Execute command Move");
        }
    }
}