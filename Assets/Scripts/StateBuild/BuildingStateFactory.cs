using BuildingState;
using System;
public interface IBuildingStateFactory
{
    IBuildingState CreateState(BuildingStateType stateName);
}

public class BuildingStateFactory : IBuildingStateFactory
{
    public IBuildingState CreateState(BuildingStateType stateName)
    {
        return stateName switch
        {
            BuildingStateType.Built => new BuiltState(),
            BuildingStateType.Destroyed => new DestroyedState(),
            BuildingStateType.UnderConstruction => new UnderConstructionState(),
            BuildingStateType.Move => new MoveState(),
            BuildingStateType.PlanningBuild => new PlanningBuildState(),
            _ => throw new ArgumentException($"Unknown state: {stateName}")
        };
    }
}
