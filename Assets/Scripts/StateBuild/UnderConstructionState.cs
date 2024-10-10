using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;

public class UnderConstructionState : IBuildingState
{
    private Coroutine _constructionCoroutine;
    private DateTime _startTime; // Час початку будівництва
    private DateTime _endTime;   // Час завершення будівництва

    public void SetDateTime(string start, string end)
    {
        _startTime = DateTime.Parse(start);
        _endTime = DateTime.Parse(end);
    }

    public void Enter(BuildingContext context)
    {
     
        // Логіка входження в стан "Будується"
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
        // Логіка оновлення в стані "Будується"
    }
    private void CheckElapsedTime(BuildingContext context)
    {
        // Поточний час
        DateTime currentTime = DateTime.Now;

        // Перевіряємо, скільки часу пройшло з моменту початку будівництва
        if (currentTime >= _endTime)
        {
            // Якщо час завершено, одразу переходимо до стану завершеного будівництва
            context.TransitionToState(context.BuiltState);
        }
        else
        {
            // Якщо ще не завершено, продовжуємо будувати
            TimeSpan timeElapsed = currentTime - _startTime;
            float remainingTime = (float)(_endTime - currentTime).TotalSeconds;

            // Оновлюємо прогрес на UI
            context.BuildView.UpdateProgres(remainingTime);

            // Запускаємо корутину для завершення
            _constructionCoroutine = context.StartCoroutine(ConstructionProcess(context, remainingTime));
        }
    }
    private IEnumerator ConstructionProcess(BuildingContext context, float timeRemaining)
    {
        while (timeRemaining > 0)
        {
            timeRemaining --;
            if(timeRemaining <= 0) timeRemaining = 0;

            // Оновлюємо в'ю з прогресом
            context.BuildView.UpdateProgres(timeRemaining);

            yield return new WaitForSeconds(1);
        }

        // Будівництво завершене
        context.TransitionToState(context.BuiltState);

    }

}
