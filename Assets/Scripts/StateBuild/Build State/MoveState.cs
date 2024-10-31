using Buildings;
using UnityEngine;
using ViewBuildings;

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

            context.IsMoving = true;

            ShowPanel(context);

        }

        public void Exit(BuildingContext context)
        {   
            context.gameObject.transform.position = context.BuildData.BuildPosition.ToVector3();
            context.IsMoving = false;
            ShowPanel(context);
        }

        public void ShowPanel(BuildingContext context)
        {
            if (context.CurrentState is not PlanningBuildState)
                context.MoveBuildView.ShowStatePanel();   
        }

        public void Update(BuildingContext context)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        _isDragging = true;
                        break;

                    case TouchPhase.Moved:
                        MoveBuilding(context);
                        break;

                    case TouchPhase.Ended:
                        _isDragging = false;
                        break;
                }
            }
        }

        public void MoveBuilding(BuildingContext go)
        {
            if (_isDragging)
            { 
                Ray ray = _camera.ScreenPointToRay(Input.GetTouch(0).position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.TryGetComponent(out HexCell hex))
                    {
                        go.transform.position = hex.transform.position;

                        go.BuildData.BuildPosition = new SerializableVector3(hex.transform.position);
                    }
                }
            }
        }    
    }
}