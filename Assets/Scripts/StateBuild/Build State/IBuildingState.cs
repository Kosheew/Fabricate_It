public interface IBuildingState
{
    void Enter(BuildingContext context);
    void Exit(BuildingContext context);
    void Update(BuildingContext context);
}
