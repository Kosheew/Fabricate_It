using Buildings;
using Command.Build;
using Command;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBuild : MonoBehaviour
{
    [SerializeField] private BuildingContext _build;
    [SerializeField] private bool _building;

    private Camera _camera;
    void Start()
    {
        _camera = Camera.main;
    }

    private bool _isDragging = false;

    // Update is called once per frame
    void Update()
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
                    MoveBuilding(_build);
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
        EndBuilding();
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

                    EndBuilding();
                
            }
        }
    }

    public void StartBuild()
    {
        _building = true;
        _build.gameObject.SetActive(true);
    }

    public void EndBuilding()
    {
        _building = false;


        ICommand buyCommand = new BuildBuy(_build);
        CommandInvoker invoker = new CommandInvoker();
        invoker.SetCommand(buyCommand);
        invoker.ExecuteCommands();
    }
}
