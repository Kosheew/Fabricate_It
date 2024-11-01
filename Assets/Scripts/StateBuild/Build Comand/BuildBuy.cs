using Buildings;

namespace CommandBuild.Build
{
    public class BuildBuy : Command
    {
        private BuildingContext _context;
        
        public BuildBuy(BuildingContext context)
        {
            _context = context; 
        }

        public override void Execute()
        {
            if (!_context.BuildData.Bought)
            {
               // _context.SetUpgradeFlag(true);
                _context.BuildData.Bought = true;
                _context.TransitionToState(_context.UnderConstructionState);
            }
        }
    }
}