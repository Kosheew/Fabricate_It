using Buildings;
using UnityEngine;
namespace Command.Build
{
    public class StartPlacmentCommand : ICommand
    {
        private BuildingContext _context;

        public StartPlacmentCommand(BuildingContext context)
        {
            _context = context;
        }

        public void Execute()
        {
            _context.MoveBuildState.Enter(_context);
            Debug.Log("Execute command Move");
        }
    }
}