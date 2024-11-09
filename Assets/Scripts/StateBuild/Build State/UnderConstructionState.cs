using System.Collections;
using UnityEngine;
using System;
using Buildings;

namespace BuildingState
{
    public class UnderConstructionState : IBuildingState
    {
        private Coroutine _constructionCoroutine;
        private DateTime _startTime;
        private DateTime _endTime;

        public void Enter(BuildingContext context)
        {
            context.MeshBuild.mesh = context.BuildSettings.MeshUnderConstrucrion;
            context.BuildData.CurrentState = nameof(BuildingContext);

            float buildDuration = context.TimeBuilding;

            if (!DateTime.TryParse(context.EndTime, out _endTime))
            {
                _startTime = DateTime.Now;
                _endTime = _startTime.AddSeconds(buildDuration);
                context.EndTimeBuilding = _endTime;
                context.BuildData.EndTimeBuilding = _endTime.ToString("o");
                context.BuildData.CurrentState = nameof(UnderConstructionState);
            }
            else
            {
                _endTime = DateTime.Parse(context.EndTime);
                context.EndTimeBuilding = _endTime;
            }

            context.BuildView.StartBuilding();
            context.BuildView.SetTimeBuilding(buildDuration);
            CheckElapsedTime(context);
        }

        public void Exit(BuildingContext context)
        {
            context.BuildData.LevelBuild++;
            context.BuildView.EndBuilding();
        }

        public void ShowPanel(BuildingContext context)
        {
            context.SpeedUpView.ShowStatePanel();
        }

        public void Update(BuildingContext context)
        {
          
        }
        private void CheckElapsedTime(BuildingContext context)
        {
            DateTime currentTime = DateTime.Now;

            if (currentTime >= _endTime)
            {
                context.TransitionToState(context.BuiltState);
            }
            else
            {
                float remainingTime = (float)(_endTime - currentTime).TotalSeconds;
                _constructionCoroutine = context.StartCoroutine(ConstructionProcess(context, remainingTime));
            }
        }
        private IEnumerator ConstructionProcess(BuildingContext context, float timeRemaining)
        {
            while (timeRemaining > 0)
            {
                timeRemaining--;
                if (timeRemaining <= 0) timeRemaining = 0;

                context.BuildView.UpdateProgress(timeRemaining);

                yield return new WaitForSeconds(1);
            }

            context.BuildData.LevelBuild++;
            context.TransitionToState(context.BuiltState);
            _constructionCoroutine = null;

        }

    }
}