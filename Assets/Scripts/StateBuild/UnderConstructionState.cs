using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;

public class UnderConstructionState : IBuildingState
{
    private Coroutine _constructionCoroutine;
    private DateTime _startTime; // ��� ������� ����������
    private DateTime _endTime;   // ��� ���������� ����������

    public void SetDateTime(string start, string end)
    {
        _startTime = DateTime.Parse(start);
        _endTime = DateTime.Parse(end);
    }

    public void Enter(BuildingContext context)
    {
     
        // ����� ��������� � ���� "��������"
        Debug.Log("Building is now Under Construction.");

        float buildDuration = context.TimeBuilding;

        _startTime = DateTime.Parse(context.StartTime);
        _endTime = DateTime.Parse(context.EndTime);

        if (_startTime == null)
        {
            _startTime = DateTime.Now;
            _endTime = _startTime.AddSeconds(buildDuration);
        }

        CheckElapsedTime(context);       
    }

    public void Exit(BuildingContext context)
    {
        PlayerPrefs.DeleteKey("StartTime");
        PlayerPrefs.DeleteKey("EndTime");
        PlayerPrefs.Save();

        context.BuildView.EndBuilding();
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

            // ��������� ������� �� UI
            context.BuildView.UpdateProgres(remainingTime);

            // ��������� �������� ��� ����������
            _constructionCoroutine = context.StartCoroutine(ConstructionProcess(context, remainingTime));
        }
    }
    private IEnumerator ConstructionProcess(BuildingContext context, float timeRemaining)
    {
        while (timeRemaining > 0)
        {
            timeRemaining --;
            if(timeRemaining <= 0) timeRemaining = 0;

            // ��������� �'� � ���������
            context.BuildView.UpdateProgres(timeRemaining);

            yield return new WaitForSeconds(1);
        }

        // ���������� ���������
        context.TransitionToState(context.BuiltState);

    }

}
