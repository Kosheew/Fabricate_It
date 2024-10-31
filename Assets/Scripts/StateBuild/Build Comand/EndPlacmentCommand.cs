using Buildings;
using UnityEngine;
namespace Command.Build
{
    public class EndPlacmentCommand : ICommand
    {
        private BuildingContext _context;

        public EndPlacmentCommand(BuildingContext context)
        {
            _context = context;
        }

        public void Execute()
        {
            _context.MoveBuildState?.Exit(_context);
            Debug.Log("Execute command Move");
        }
    }
}