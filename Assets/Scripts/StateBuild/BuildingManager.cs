using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    public BuildingContext buildingContext;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            buildingContext.TransitionToState(buildingContext.BuiltState);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            buildingContext.TransitionToState(buildingContext.DestroyedState);
        }
        else if (Input.GetKeyDown(KeyCode.U))
        {
            buildingContext.TransitionToState(buildingContext.UnderConstructionState);
        }
    }
}