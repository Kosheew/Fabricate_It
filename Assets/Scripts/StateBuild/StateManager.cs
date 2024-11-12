using Buildings;
using BuildingState;

namespace Managers
{
    public class StateManager
    {
        private IBuildingState _currentState;

        public StateManager()
        {
        }

        public void SetState(IBuildingState newState, BuildingContext context)
        {
            _currentState?.Exit(context);
            _currentState = newState;
            _currentState.Enter(context);
        }

        public void UpdateState(BuildingContext context)
        {
            _currentState?.Update(context);
        }

        public void ShowStatePanel(BuildingContext context)
        {
            _currentState?.ShowPanel(context);
        }
    }
}
