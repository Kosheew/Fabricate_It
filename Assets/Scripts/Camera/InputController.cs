using Buildings;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    private Camera _camera;
    private CommandBuildFabric _commandBuildFabric;

    public void Init(CommandBuildFabric commandBuildFabric)
    {
        _camera = Camera.main;
        _commandBuildFabric = commandBuildFabric;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = _camera.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.TryGetComponent(out BuildingContext context))
                {
                    _commandBuildFabric.SetBuild(context);
                    context.ShowPanel();
                }
            }
        }
    }
}
