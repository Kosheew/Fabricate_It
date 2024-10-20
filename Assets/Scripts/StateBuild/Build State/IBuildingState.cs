using Buildings;

namespace BuildingState
{
    public interface IBuildingState
    {
        void Enter(BuildingContext context);
        void Exit(BuildingContext context);
        void Update(BuildingContext context);

        void ShowPanel(BuildingContext context);
    }
}