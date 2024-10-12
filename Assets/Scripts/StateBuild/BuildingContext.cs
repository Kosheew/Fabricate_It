using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BuildingContext : MonoBehaviour
{
    public bool NeedsUpgrade { get; private set; }
    public bool NeedsRepair { get; private set; }
    public IBuildingState CurrentState => _currentState;

    public float TimeBuilding {  get; private set; }
    public BuildView BuildView { get; private set; }

    public string StartTime { get; private set; }
    public string EndTime { get; private set; }

    private IBuildingState _currentState;

    public IBuildingState BuiltState { get; private set; }
    public IBuildingState DestroyedState { get; private set; }
    public IBuildingState UnderConstructionState { get; private set; }

    public BuildData BuildData;

    public void Init(BuildData data)
    {
        BuildData = data;   
        TimeBuilding = data.TimeBuilding;
        StartTime = data.StartTimeBuilding;
        EndTime = data.EndTimeBuilding;

        BuiltState = new BuiltState();
        DestroyedState = new DestroyedState();
        UnderConstructionState = new UnderConstructionState();

        BuildView = GetComponent<BuildView>();

        BuildView.SetTimeBuilding(TimeBuilding);

        // Початковий стан
        TransitionToState(UnderConstructionState);

        StartCoroutine(UpdateState());
    }

    public void ReduceBuildTime(float seconds)
    {
        // Зменшуємо час будівництва
        TimeBuilding -= seconds;
        if (TimeBuilding <= 0)
        {
            TransitionToState(BuiltState);
        }
    }

    private IEnumerator UpdateState()
    {
        while (true)
        {
            _currentState?.Update(this);
            yield return new WaitForSeconds(1);
        }
    }

    public void SetUpgradeFlag(bool value)
    {
        NeedsUpgrade = value;
    }

    public void SetRepairFlag(bool value)
    {
        NeedsRepair = value;
    }

    public void TransitionToState(IBuildingState newState)
    {
        _currentState?.Exit(this);
        _currentState = newState;
        _currentState.Enter(this);
    }
}
