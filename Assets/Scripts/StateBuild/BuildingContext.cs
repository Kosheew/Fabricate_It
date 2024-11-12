using System.Collections;
using UnityEngine;
using CommandBuild;
using CommandBuild.Build;
using BuildingState;
using ViewBuildings;
using System;
using System.Collections.Generic;

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

        [SerializeField] public MeshFilter _meshBuild;
        [SerializeField] public MeshFilter _meshGex;

        [SerializeField] public MeshRenderer _materialBuild;
        [SerializeField] public MeshRenderer _materialGex;

        public MeshFilter MeshBuild => _meshBuild;
        public MeshFilter MeshGex => _meshGex;

        public MeshRenderer MaterialBuild => _materialBuild;
        public MeshRenderer MaterialGex => _materialGex;

        public BuildSettings BuildSettings => _buildSettings;

        public BuildData BuildData { get; private set; }

        public string EndTime { get; private set; }
        private int BuildLevel { get; set; }
        public bool IsMoving { get; set; }

        public DateTime EndTimeBuilding;   

        public Transform NewPosition { get; private set; }

        public void Init(BuildData data)
        {   
            BuildData = data;
            
            EndTime = data.EndTimeBuilding;
            BuildLevel = data.LevelBuild;

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

        public List<IResource> GetResourcesUpgrade()
        {
            return _buildSettings.LeveResources[BuildLevel].UpgradeResources.ToResourceList();
        }

        public int GetTimeBuilding()
        {
            int timeBuilding = _buildSettings.LeveResources[BuildLevel].TimeBuild;
            BuildData.TimeBuilding = timeBuilding;
            return timeBuilding;
        }

        public void UpgradeLevel()
        {
            BuildLevel++;
            BuildData.LevelBuild = BuildLevel;
        }
    }
}