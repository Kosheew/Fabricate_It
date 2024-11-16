using Buildings;

namespace BuildingState
{
    public class PlanningBuildState : IBuildingState
    {
        public void Enter(BuildingContext context)
        {
            context.gameObject.SetActive(true);
            ShowPanel(context);
        }

        public void Exit(BuildingContext context)
        {
            ShowPanel(context);
        }

        public void ShowPanel(BuildingContext context)
        {
           context.PlanningBuildView.ShowStatePanel();
        }

        public void Update(BuildingContext context)
        {
            
        }
    }
}