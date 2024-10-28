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
            context.Collider.enabled = true;

            context.BuildData.Bought = true;
            context.gameObject.SetActive(true);
            context.gameObject.transform.position = context.BuildData.BuildPosition.ToVector3();

            context.MeshBuild.mesh = context.BuildSettings.MeshUnderConstrucrion;
            Debug.Log("Building is now Under Construction.");

            float buildDuration = context.TimeBuilding;


            if (!DateTime.TryParse(context.EndTime, out _endTime))
            {
                _startTime = DateTime.Now;
                _endTime = _startTime.AddSeconds(buildDuration);
                context.BuildData.EndTimeBuilding = _endTime.ToString("o");
                context.BuildData.CurrentState = nameof(UnderConstructionState);
            }
            else
            {
                _endTime = DateTime.Parse(context.EndTime);
            }
            context.ConstructionProgressView.StartBuilding();
            context.ConstructionProgressView.SetTimeBuilding(buildDuration);
            CheckElapsedTime(context);
        }

        public void Exit(BuildingContext context)
        {
            

            context.MeshBuild.mesh = context.BuildSettings.MeshBuilding;

            context.ConstructionProgressView.EndBuilding();
        }

        public void ShowPanel(BuildingContext context)
        {
            context.ConstructionProgressView.ShowStatePanel();
        }

        public void Update(BuildingContext context)
        {
            // ����� ��������� � ���� "��������"
        }
        private void CheckElapsedTime(BuildingContext context)
        {
            // �������� ���
            DateTime currentTime = DateTime.Now;

            // ����������, ������ ���� ������� � ������� ������� ����������
            if (currentTime >= _endTime)
            {
                // ���� ��� ���������, ������ ���������� �� ����� ����������� ����������
                context.TransitionToState(context.BuiltState);
            }
            else
            {
                // ���� �� �� ���������, ���������� ��������
                TimeSpan timeElapsed = currentTime - _startTime;
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

                // ��������� �'� � ���������
                context.ConstructionProgressView.UpdateProgress(timeRemaining);

                yield return new WaitForSeconds(1);
            }

            context.BuildData.LevelBuild++;
            // ���������� ���������
            context.TransitionToState(context.BuiltState);
            _constructionCoroutine = null;

        }

    }
}