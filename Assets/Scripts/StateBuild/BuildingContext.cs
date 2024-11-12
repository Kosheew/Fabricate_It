using System.Collections;
using UnityEngine;
using CommandBuild;
using CommandBuild.Build;
using BuildingState;
using ViewBuildings;
using System;

namespace Buildings
{
    public class BuildingContext : MonoBehaviour
    {
        [SerializeField] private BuildSettings _buildSettings;
        
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
        public BuildView BuildView { get; private set; }
        public View MoveBuildView { get; private set; }
        public View PlanningBuildView { get; private set; }
        public View RepairBuildView { get; private set; }
        public View SpeedUpView { get; private set; }
        public View StateBuildView { get; private set; }

        public MeshFilter MeshBuild { get; private set; }
        public BuildSettings BuildSettings => _buildSettings;

        public BuildData BuildData { get; private set; }

        public float TimeBuilding { get; private set; }
        public string EndTime { get; private set; }
        public int BuildLevel { get; set; }
        public bool IsMoving { get; set; }

        public DateTime EndTimeBuilding;   

        public Transform NewPosition { get; private set; }

        public void Init(BuildData data)
        {
            MeshBuild = GetComponentInChildren<MeshFilter>();
        
            BuildData = data;
            
            EndTime = data.EndTimeBuilding;
            BuildLevel = data.LevelBuild;

            data.TimeBuilding = _buildSettings.LeveResources[BuildLevel].TimeBuild;
            TimeBuilding = data.TimeBuilding;

            BuiltState = new BuiltState();
            DestroyedState = new DestroyedState();
            UnderConstructionState = new UnderConstructionState();
            MoveBuildState = new MoveState();
            PlanningBuildState = new PlanningBuildState();  

            BuildView = GetComponent<BuildView>();

            MoveBuildView = FindAnyObjectByType<MoveBuildView>();
            PlanningBuildView = FindAnyObjectByType<PlanningBuildView>();
            RepairBuildView = FindAnyObjectByType<RepairBuildingView>();
            SpeedUpView = FindAnyObjectByType<SpeedUpView>();
            StateBuildView = FindAnyObjectByType<StateBuildingView>();

            if (data.Bought)
            {
                gameObject.SetActive(true);
                transform.position = data.BuildPosition.ToVector3();  
                
                Type stateType = Type.GetType("BuildingState." + data.CurrentState);

                IBuildingState stateInstance = (IBuildingState)Activator.CreateInstance(stateType);

                TransitionToState(stateInstance);
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

        public void TransitionToState(IBuildingState newState)
        {
            CurrentState?.Exit(this);
            CurrentState = newState;
            CurrentState.Enter(this);
        }

        public void SetPosition(Transform newPos)
        {
            NewPosition = newPos;
        }

        public void ShowPanel()
        {
            if (!IsMoving)
                CurrentState?.ShowPanel(this);
        }
    }
}