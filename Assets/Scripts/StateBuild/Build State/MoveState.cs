using Buildings;
using BuildingState;
using Command.Build;
using Command;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BuildingState
{
    public class MoveState : IBuildingState
    {
        private bool _isDragging = false;
        private Camera _camera;

        public void Enter(BuildingContext context)
        {
            Debug.Log("Start Move");
            _camera = Camera.main;

            context.CurrentState.ShowPanel(context);
            ShowPanel(context);

        }

        public void Exit(BuildingContext context)
        {
           
        }

        public void ShowPanel(BuildingContext context)
        {
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
                        StartDragging();
                        break;

                    case TouchPhase.Moved:
                        MoveBuilding(context);
                        break;

                    case TouchPhase.Ended:
                        EndDragging();
                        break;
                }
            }
        }

        private void StartDragging()
        {
            _isDragging = true;

        }

        private void EndDragging()
        {
            _isDragging = false;
            
        }

        public void MoveBuilding(BuildingContext go)
        {
            if (!_isDragging) return;

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