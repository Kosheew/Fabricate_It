using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UnderConstructionState : IBuildingState
{
    private Coroutine _constructionCoroutine;
    private DateTime _startTime; // ��� ������� ����������
    private DateTime _endTime;   // ��� ���������� ����������

    public void Enter(BuildingContext context)
    {
     
        // ����� ��������� � ���� "��������"
        Debug.Log("Building is now Under Construction.");

        float buildDuration = context.TimeBuilding;

        if (PlayerPrefs.HasKey("StartTime") && PlayerPrefs.HasKey("EndTime"))
        {
            _startTime = DateTime.Parse(PlayerPrefs.GetString("StartTime"));
            _endTime = DateTime.Parse(PlayerPrefs.GetString("EndTime"));
        }
        else
        {
            _startTime = DateTime.Now;
            _endTime = _startTime.AddSeconds(buildDuration);
            PlayerPrefs.SetString("StartTime", _startTime.ToString());
            PlayerPrefs.SetString("EndTime", _endTime.ToString());
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
