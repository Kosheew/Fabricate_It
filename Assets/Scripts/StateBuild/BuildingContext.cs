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
        /// View Build
        /// </summary>
        public BuildrocessView BuildView { get; private set; }
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

        public StateManager StateManager { get; private set; }

        private BuildingVisualManager _buildingVisualManager;

        public void Init(DependencyContainer container)
        {
            int index = _buildSettings.Index;

            BuildData = container.Resolve<List<BuildData>>()[index];

           // var stateFactory = container.Resolve<BuildingStateFactory>();
            StateManager = container.Resolve<StateManager>();

            List<View> view = container.Resolve<List<View>>();
            
            _buildingVisualManager = new BuildingVisualManager(_meshBuild, _materialBuild, _materialGex, _buildSettings);
            
            BuildView = GetComponent<BuildrocessView>();

            MoveBuildView = view.OfType<MoveBuildView>().FirstOrDefault();
            PlanningBuildView = view.OfType<PlanningBuildView>().FirstOrDefault();
            RepairBuildView = view.OfType<RepairBuildingView>().FirstOrDefault();
            SpeedUpView = view.OfType<SpeedUpView>().FirstOrDefault();
            StateBuildView = view.OfType<StateBuildingView>().FirstOrDefault();


            EndTime = BuildData.EndTimeBuilding;
            BuildLevel = BuildData.LevelBuild;

            if (BuildData.Bought)
            {
                gameObject.SetActive(true);
                transform.position = BuildData.BuildPosition.ToVector3();  
                
                Type stateType = Type.GetType("BuildingState." + BuildData.CurrentState);

                IBuildingState stateInstance = (IBuildingState)Activator.CreateInstance(stateType);

                StateManager.SetState(stateInstance, this);
            }
        }

        private void Update()
        {
            StateManager?.UpdateState(this);
        }

        public void TransitionToState(IBuildingState newState)
        {
            StateManager.SetState(newState, this);
        }

        public void SetPosition(Transform newPos)
        {
            NewPosition = newPos;
        }

        public void ShowPanel()
        {
            StateManager.ShowStatePanel(this);
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