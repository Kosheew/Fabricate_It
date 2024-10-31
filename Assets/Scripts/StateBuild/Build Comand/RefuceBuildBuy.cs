using Buildings;

namespace Command.Build
{
    public class RefuceBuildBuy : ICommand
    {
        private BuildingContext _context;
        
        public RefuceBuildBuy(BuildingContext context)
        {
            _context = context; 
        }

        public void Execute()
        {
            _context.gameObject.SetActive(false);
            _context.CurrentState.Exit(_context);
        }
    }
}