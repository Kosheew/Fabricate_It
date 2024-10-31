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
        /// <summary>
        /// State Building
        /// </summary>
        public IBuildingState CurrentState { get; private set; }
        public IBuildingState BuiltState { get; private set; }
        public IBuildingState DestroyedState { get; private set; }
        public IBuildingState UnderConstructionState { get; private set; }
        public IBuildingState MoveBuildState { get; private set; }
        public IBuildingState PlanningBuildState { get; private set; }

        /// <summary>
        /// View Build
        /// </summary>
        public View UpgradeOrViewBuildingView { get; private set; }
        public View RestoreBuildingView { get; private set; }
        public ConstructionProgressView ConstructionProgressView { get; private set; }
        public View MoveBuildView { get; private set; }
        public View PlainningBuildView { get; private set; }

        public CommandInvoker Invoker { get; private set; }


        [SerializeField] private BuildSettings _buildSettings;

        public MeshFilter MeshBuild { get; private set; }
        public BuildSettings BuildSettings => _buildSettings;

        public BuildData BuildData;

        public bool NeedsUpgrade { get; private set; }
        public bool NeedsRepair { get; private set; }
        public float TimeBuilding { get; private set; }
        public string EndTime { get; private set; }
       
        public bool IsMoving = false;

        public void Init(BuildData data)
        {
            MeshBuild = GetComponentInChildren<MeshFilter>();

            BuildData = data;
            TimeBuilding = data.TimeBuilding;
            EndTime = data.EndTimeBuilding;

            BuiltState = new BuiltState();
            DestroyedState = new DestroyedState();
            UnderConstructionState = new UnderConstructionState();
            MoveBuildState = new MoveState();
            PlanningBuildState = new PlanningBuildState();  

            UpgradeOrViewBuildingView = GetComponent<UpgradeOrViewBuildingView>();
            UpgradeOrViewBuildingView.Init();

            RestoreBuildingView = GetComponent<RestoreBuildingView>();
            RestoreBuildingView.Init();

            ConstructionProgressView = GetComponent<ConstructionProgressView>();
            ConstructionProgressView.Init();

            MoveBuildView = GetComponent<MoveBuildView>();
            MoveBuildView.Init();

            PlainningBuildView = GetComponent<PlainningBuildView>();
            PlainningBuildView.Init();

            if (data.Bought)
            {
                transform.position = data.BuildPosition.ToVector3();
                gameObject.SetActive(true);
                // Початковий стан
                TransitionToState(UnderConstructionState);
                //StartCoroutine(UpdateState());
            }
          
        }

        public void ReduceBuildTime(float seconds)
        {
            TimeBuilding -= seconds;
            if (TimeBuilding <= 0)
            {
                TransitionToState(BuiltState);
            }
        }

        private void Update()
        {
            CurrentState?.Update(this);
            if (IsMoving)
            {
                MoveBuildState?.Update(this);  
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
            if (!IsMoving)
                CurrentState.ShowPanel(this);
        }
    }
}