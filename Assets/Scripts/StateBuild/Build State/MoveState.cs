using Buildings;
using UnityEngine;

namespace BuildingState
{
    public class MoveState : IBuildingState
    {
        private bool _isDragging = false;
        private Camera _camera;

        public void Enter(BuildingContext context)
        {
            context.gameObject.SetActive(true);

            _camera = Camera.main;

            context.BuildView.ShowMovePanel();
            context.IsMoving = true;

            _isDragging = true;

            ShowPanel(context);

            Debug.Log("I mveble State");

        }

        public void Exit(BuildingContext context)
        {
            context.BuildData.BuildPosition = new SerializableVector3(context.transform.position);

            context.IsMoving = false;
            _isDragging = false;

            context.BuildView.ShowMovePanel();
        }

        public void ShowPanel(BuildingContext context)
        {
            if (context.BuildData.Bought)
                context.MoveBuildView.ShowStatePanel();   
        }

        public void Update(BuildingContext context)
        {
            if(_isDragging && context.NewPosition != null)
            {
                context.gameObject.transform.position = context.NewPosition.position;
            }
        } 
    }
}