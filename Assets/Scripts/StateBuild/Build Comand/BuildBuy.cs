using Buildings;

namespace Command.Build
{
    public class BuildBuy : ICommand
    {
        private BuildingContext _context;
        
        public BuildBuy(BuildingContext context)
        {
            _context = context; 
        }

        public void Execute()
        {
            if (!_context.BuildData.Bought)
            {
                _context.SetUpgradeFlag(true);
                _context.TransitionToState(_context.UnderConstructionState);
            }
        }
    }
}