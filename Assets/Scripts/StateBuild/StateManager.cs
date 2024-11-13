using Buildings;
using BuildingState;

namespace Managers
{
    public class StateManager
    {
        private IBuildingState _currentState;

        public IBuildingState MoveState { get; set; }
        public IBuildingState PlacmentState { get; set; }

        public StateManager()
        {
        }

        public void SetMove(IBuildingState newState, BuildingContext context)
        {
            MoveState = newState;
            MoveState.Enter(context);
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
            MoveState?.Update(context);
        }

        public void ShowStatePanel(BuildingContext context)
        {
            _currentState?.ShowPanel(context);
        }
    }
}
