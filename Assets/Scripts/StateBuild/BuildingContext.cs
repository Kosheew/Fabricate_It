using System.Collections;
using UnityEngine;
using CommandBuild;
using CommandBuild.Build;
using BuildingState;
using ViewBuildings;
using System;
using System.Collections.Generic;
using System.Linq;
using Managers;

namespace Buildings
{
    public class BuildingContext : MonoBehaviour
    {
        [SerializeField] private BuildSettings _buildSettings;
        
        /// <summary>
        /// State Building
        /// </summary>
        public IBuildingState CurrentState { get; private set; }

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

        [SerializeField] public MeshRenderer _materialBuild;
        [SerializeField] public MeshRenderer _materialGex;


        public BuildSettings BuildSettings => _buildSettings;

        public BuildData BuildData { get; private set; }

        public string EndTime { get; private set; }
        private int BuildLevel { get; set; }
        public bool IsMoving { get; set; }

        public DateTime EndTimeBuilding;   

        public Transform NewPosition { get; private set; }

        private StateManager _stateManager;

        private BuildingVisualManager _buildingVisualManager;

        public void Init(BuildData data, StateManager stateManager,  List<View> _view)
        {   
            BuildData = data;
            
            EndTime = data.EndTimeBuilding;
            BuildLevel = data.LevelBuild;

            _stateManager = stateManager;

            _buildingVisualManager = new BuildingVisualManager(_meshBuild, _materialBuild, _materialGex, _buildSettings);

            BuildView = GetComponent<BuildView>();

            MoveBuildView = _view.OfType<MoveBuildView>().FirstOrDefault();
            PlanningBuildView = _view.OfType<PlanningBuildView>().FirstOrDefault();
            RepairBuildView = _view.OfType<RepairBuildingView>().FirstOrDefault();
            SpeedUpView = _view.OfType<SpeedUpView>().FirstOrDefault();
            StateBuildView = _view.OfType<StateBuildingView>().FirstOrDefault();

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
            _stateManager.UpdateState(this);
            CurrentState?.Update(this);
            if (IsMoving)
            {
              //  MoveBuildState?.Update(this);  
            }
        }

        public void TransitionToState(IBuildingState newState)
        {
            _stateManager.SetState(newState, this);
        }

        public void SetPosition(Transform newPos)
        {
            NewPosition = newPos;
        }

        public void ShowPanel()
        {
            if (!IsMoving)
                _stateManager.ShowStatePanel(this);
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