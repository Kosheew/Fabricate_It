using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BuildingContext : MonoBehaviour
{
    public float TimeBuilding {  get; private set; }
    public BuildView BuildView { get; private set; }

    
    private IBuildingState _currentState;

    public IBuildingState BuiltState { get; private set; }
    public IBuildingState DestroyedState { get; private set; }
    public IBuildingState UnderConstructionState { get; private set; }

    public void Awake()
    {
        BuiltState = new BuiltState();
        DestroyedState = new DestroyedState();
        UnderConstructionState = new UnderConstructionState();

        BuildView = GetComponent<BuildView>();
        TimeBuilding = 6660;
        BuildView.SetTimeBuilding(TimeBuilding);

        // Початковий стан
        TransitionToState(UnderConstructionState);

        StartCoroutine(UpdateState());
    }

    private IEnumerator UpdateState()
    {
        while (true)
        {
            _currentState?.Update(this);
            yield return new WaitForSeconds(1);
        }
    }


    public void TransitionToState(IBuildingState newState)
    {
        _currentState?.Exit(this);
        _currentState = newState;
        _currentState.Enter(this);
    }
}
