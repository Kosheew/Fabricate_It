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

    // Update is called once per frame
    void Update()
    {
        if(_building)
        {
            MoveBuilding(_build);
        }
    }

    public void MoveBuilding(BuildingContext go)
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.TryGetComponent(out HexCell hex))
            {
                go.transform.position = hex.transform.position;
                if (Input.GetMouseButtonDown(0))
                {
                    go.transform.position = hex.transform.position;

                    go.BuildData.BuildPosition = new SerializableVector3(hex.transform.position);

                    EndBuilding();
                }
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
