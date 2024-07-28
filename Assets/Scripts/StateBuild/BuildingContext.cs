using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BuildingContext : MonoBehaviour
{
    private IBuildingState _currentState;

    public IBuildingState BuiltState { get; private set; }
    public IBuildingState DestroyedState { get; private set; }
    public IBuildingState UnderConstructionState { get; private set; }

    private void Start()
    {
        BuiltState = new BuiltState();
        DestroyedState = new DestroyedState();
        UnderConstructionState = new UnderConstructionState();

        // Початковий стан
        TransitionToState(UnderConstructionState);
    }

    private void Update()
    {
        _currentState?.Update(this);
    }

    public void TransitionToState(IBuildingState newState)
    {
        _currentState?.Exit(this);
        _currentState = newState;
        _currentState.Enter(this);
    }
}
