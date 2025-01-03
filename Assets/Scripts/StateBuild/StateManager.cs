using Buildings;
using BuildingState;
using System.Collections.Generic;

namespace Managers
{
    public class StateManager
    {
        private Dictionary<BuildingContext, IBuildingState> _states = new();

        /// <summary>
        /// ���� ���������� ��'����.
        /// </summary>
        public IBuildingState MoveState { get; private set; }

        /// <summary>
        /// ����, �� ������� �� ������� �����.
        /// </summary>
        public IBuildingState PlacmentState { get; private set; }

        public StateManager(BuildingStateFactory stateFactory)
        {
            MoveState = stateFactory.CreateState(BuildingStateType.Move);
            PlacmentState = stateFactory.CreateState(BuildingStateType.PlanningBuild);
        }

        /// <summary>
        /// ������ ���������� ��'����.
        /// </summary>
        public void StartMove(BuildingContext context)
        {
            MoveState.Enter(context);
        }

        /// <summary>
        /// ���������� ���������� ��'����.
        /// </summary>
        public void StopMove(BuildingContext context)
        {
            MoveState?.Exit(context);
        }

        /// <summary>
        /// ������������ ��������� �����.
        /// </summary>
        public void SetState(IBuildingState newState, BuildingContext context)
        {
            if (_states.ContainsKey(context))
            {
                _states[context].Exit(context);
            }

            _states[context] = newState;
            newState.Enter(context);
        }

        /// <summary>
        /// ��������� ��������� ����� �� MoveState.
        /// </summary>
        public void UpdateState(BuildingContext context)
        {
            if (_states.TryGetValue(context, out var state))
            {
                state.Update(context);
            }

            if (context.IsMoving)
            {
                MoveState?.Update(context);
            }
        }

        /// <summary>
        /// ����� ����� ��� ��������� �����.
        /// </summary>
        public void ShowStatePanel(BuildingContext context)
        {
            if (!context.IsMoving && _states.TryGetValue(context, out var state))
            {
                state.ShowPanel(context);
            }
        }

        /// <summary>
        /// ������ ����� � ��������� ����������.
        /// </summary>
        public void StartPurchaseWithMove(BuildingContext context)
        {
            PlacmentState.Enter(context);
            StartMove(context);           
        }

        public void EndPurchase(BuildingContext context)
        {
            StopMove(context);
            PlacmentState.Exit(context);      
        }
    }
}
