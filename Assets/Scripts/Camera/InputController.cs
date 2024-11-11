using Buildings;
using BuildingState;
using UnityEngine;

public class InputController : MonoBehaviour
{
    private Camera _camera;
    private CommandBuildFabric _commandBuildFabric;
    public bool isDragging = false; 

    private BuildingContext _buildingContext;

    public void Init(CommandBuildFabric commandBuildFabric)
    {
        _camera = Camera.main;
        _commandBuildFabric = commandBuildFabric;
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            HandleTouchInput(touch);
        }
    }

    private void HandleTouchInput(Touch touch)
    {
        Ray ray = _camera.ScreenPointToRay(touch.position);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.TryGetComponent(out BuildingContext context))
            {
                HandleBuildingContextTouch(context);
                isDragging = touch.phase != TouchPhase.Ended;
            }
          
            if (touch.phase == TouchPhase.Moved 
                && isDragging 
                && hit.collider.TryGetComponent(out HexCell hexCell)
                && _buildingContext.IsMoving)
            {
                _buildingContext.SetPosition(hexCell.transform);
            }
        }
    }

    private void HandleBuildingContextTouch(BuildingContext context)
    {
        if (Input.GetButtonDown("Fire1"))
        {
            _commandBuildFabric.SetBuild(context);
            _buildingContext = context;
            context.ShowPanel();
        }
    }
}
