using Buildings;
using Managers;

namespace CommandBuild.Build
{
    public class RefuceBuildBuy : Command
    {
        private BuildingContext _context;
        private StateManager _stateManager;

        public RefuceBuildBuy(BuildingContext context, DependencyContainer container)
        {
            _context = context;
            _stateManager = container.Resolve<StateManager>();
        }

        public override void Execute()
        {
            _stateManager.EndPurchase(_context);
            _context.gameObject.SetActive(false);
        }
    }
}