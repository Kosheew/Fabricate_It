using Buildings;
using BuildingState;
using UnityEngine;

public class InputController : MonoBehaviour
{
    private Camera _camera;
    private CommandBuildFabric _commandBuildFabric;
    public bool IsDragging { get; private set; }

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
            ProcessTouch(touch);
        }
    }

    private void ProcessTouch(Touch touch)
    {
        Ray ray = _camera.ScreenPointToRay(touch.position);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            HandleHitObject(hit, touch);
        }
    }

    private void HandleHitObject(RaycastHit hit, Touch touch)
    {
        if (hit.collider.TryGetComponent(out BuildingContext context))
        {
            HandleBuildingTouch(context, touch);
        }
        else if (touch.phase == TouchPhase.Moved && IsDragging)
        {
            HandleDrag(hit);
        }
    }

    private void HandleBuildingTouch(BuildingContext context, Touch touch)
    {
        if (Input.GetButtonDown("Fire1"))
        {
            _commandBuildFabric.SetBuild(context);
            _buildingContext = context;
            context.ShowPanel();
        }

        if (_buildingContext?.IsMoving == true)
        {
            IsDragging = touch.phase != TouchPhase.Ended;
        }
    }

    private void HandleDrag(RaycastHit hit)
    {
        if (hit.collider.TryGetComponent(out HexCell hexCell) && _buildingContext?.IsMoving == true)
        {
            _buildingContext.SetPosition(hexCell.transform);
        }
    }
}
