using Buildings;
using BuildingState;
using System.Collections.Generic;

namespace Managers
{
    public class StateManager
    {
        private Dictionary<BuildingContext, IBuildingState> _states = new();

        /// <summary>
        /// Стан переміщення об'єкта.
        /// </summary>
        public IBuildingState MoveState { get; private set; }

        /// <summary>
        /// Стан, що відповідає за початок купівлі.
        /// </summary>
        public IBuildingState PlacmentState { get; private set; }

        public StateManager(BuildingStateFactory stateFactory)
        {
            MoveState = stateFactory.CreateState(BuildingStateType.Move);
            PlacmentState = stateFactory.CreateState(BuildingStateType.PlanningBuild);
        }

        /// <summary>
        /// Запуск переміщення об'єкта.
        /// </summary>
        public void StartMove(BuildingContext context)
        {
            MoveState.Enter(context);
        }

        /// <summary>
        /// Завершення переміщення об'єкта.
        /// </summary>
        public void StopMove(BuildingContext context)
        {
            MoveState?.Exit(context);
        }

        /// <summary>
        /// Встановлення основного стану.
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
        /// Оновлення поточного стану та MoveState.
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
        /// Показ панелі для поточного стану.
        /// </summary>
        public void ShowStatePanel(BuildingContext context)
        {
            if (!context.IsMoving && _states.TryGetValue(context, out var state))
            {
                state.ShowPanel(context);
            }
        }

        /// <summary>
        /// Запуск купівлі з підтримкою переміщення.
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
