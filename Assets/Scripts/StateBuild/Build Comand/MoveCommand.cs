using UnityEngine;
using Buildings;
using BuildingState;

namespace Command.Build
{
    public class MoveCommand : ICommand
    {
        private BuildingContext _context;

        public MoveCommand(BuildingContext context)
        {
            _context = context;
        }

        public void Execute()
        {

        }
    }
}