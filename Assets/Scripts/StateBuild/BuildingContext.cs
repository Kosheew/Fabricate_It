using System.Collections;
using UnityEngine;
using Command;
using Command.Build;
using BuildingState;
using ViewBuildings;

namespace Buildings
{
    public class BuildingContext : MonoBehaviour
    {
        [SerializeField] private BuildSettings _buildSettings;
        [SerializeField] private MeshFilter _meshBuild;

        public MeshFilter MeshBuild => _meshBuild;
        public BuildSettings BuildSettings => _buildSettings;
        public bool NeedsUpgrade { get; private set; }
        public bool NeedsRepair { get; private set; }
        public float TimeBuilding { get; private set; }
        public string EndTime { get; private set; }

        public IBuildingState CurrentState { get; private set; }

        public IBuildingState BuiltState { get; private set; }
        public IBuildingState DestroyedState { get; private set; }
        public IBuildingState UnderConstructionState { get; private set; }

        public BuildData BuildData;

        public UpgradeOrViewBuildingView UpgradeOrViewBuildingView { get; private set; }
        public RestoreBuildingView RestoreBuildingView { get; private set; }
        public ConstructionProgressView ConstructionProgressView { get; private set; }

        public void Init(BuildData data)
        {
            BuildData = data;
            TimeBuilding = data.TimeBuilding;
            EndTime = data.EndTimeBuilding;

            BuiltState = new BuiltState();
            DestroyedState = new DestroyedState();
            UnderConstructionState = new UnderConstructionState();

            UpgradeOrViewBuildingView = GetComponent<UpgradeOrViewBuildingView>();
            RestoreBuildingView = GetComponent<RestoreBuildingView>();
            ConstructionProgressView = GetComponent<ConstructionProgressView>();

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
                CurrentState?.Update(this);
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
            CurrentState?.Exit(this);
            CurrentState = newState;
            CurrentState.Enter(this);
        }

        private void OnMouseDown()
        {
            CurrentState.ShowPanel(this);
            Debug.Log("Down");
        }
    }
}