using Buildings;

namespace CommandBuild.Build
{
    public class RefuceBuildBuy : Command
    {
        private BuildingContext _context;
        
        public RefuceBuildBuy(BuildingContext context)
        {
            _context = context; 
        }

        public override void Execute()
        {
            _context.gameObject.SetActive(false);
            _context.CurrentState.Exit(_context);
        }
    }
}