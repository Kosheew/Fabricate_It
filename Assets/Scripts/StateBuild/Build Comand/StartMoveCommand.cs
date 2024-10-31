using Buildings;
using UnityEngine;
namespace Command.Build
{
    public class StartMoveCommand : ICommand
    {
        private BuildingContext _context;

        public StartMoveCommand(BuildingContext context)
        {
            _context = context;
        }

        public void Execute()
        {
            _context.StartMove();
            Debug.Log("Execute command Move");
        }
    }
}