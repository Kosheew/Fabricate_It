using Buildings;

namespace BuildingState
{
    public class PlanningBuildState : IBuildingState
    {
        public void Enter(BuildingContext context)
        {
            context.MoveBuildState.Enter(context);

            context.MaterialBuild.material = context.BuildSettings.PlacmentMaterial;
            context.MaterialGex.material = context.BuildSettings.PlacmentMaterial;

            ShowPanel(context);
        }

        public void Exit(BuildingContext context)
        {
            context.MoveBuildState.Exit(context);
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