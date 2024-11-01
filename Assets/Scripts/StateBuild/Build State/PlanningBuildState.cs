using Buildings;
using CommandBuild;
using CommandBuild.Build;
using BuildingState;
using System.Diagnostics;
using UnityEngine;

namespace BuildingState
{
    public class PlanningBuildState : IBuildingState
    {
        private CommandBuild.Command _placmentCommand;

        public void Enter(BuildingContext context)
        {
            context.MoveBuildState.Enter(context);
            ShowPanel(context);
        }

        public void Exit(BuildingContext context)
        {
            context.MoveBuildState.Exit(context);
            ShowPanel(context);
           // context.gameObject.SetActive(false);
        }

        public void ShowPanel(BuildingContext context)
        {
          //  context.PlainningBuildView.ShowStatePanel();
       
        }

        public void Update(BuildingContext context)
        {
            
        }
    }
}