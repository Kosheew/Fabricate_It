using Buildings;
using UnityEngine;
namespace Command.Build
{
    public class EndMoveCommand : ICommand
    {
        private BuildingContext _context;

        public EndMoveCommand(BuildingContext context)
        {
            _context = context;
        }

        public void Execute()
        {
            _context.EndMove();
            Debug.Log("Execute command Move");
        }
    }
}