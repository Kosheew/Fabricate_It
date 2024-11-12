using Buildings;

namespace BuildingState
{
    public class PlanningBuildState : IBuildingState
    {
        public void Enter(BuildingContext context)
        {
      //      context.MoveBuildState.Enter(context);


            ShowPanel(context);
        }

        public void Exit(BuildingContext context)
        {
        //    context.MoveBuildState.Exit(context);
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