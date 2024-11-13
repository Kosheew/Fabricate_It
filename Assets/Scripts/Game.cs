using Game.CameraControllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Buildings;
using ViewBuildings;
using System;
using Managers;

namespace Game
{
    public class Game : MonoBehaviour
    {
        [Header("Camera Controllers")]
        [SerializeField] private CameraZooming _cameraZooming;
        [SerializeField] private CameraMovement _cameraMovement;
        [SerializeField] private InputController _inputController;

        [Header("Resource View")]
        [SerializeField] private ResourceView _resourceView;
        [SerializeField] private ResourcesManager _resourcesManager;

        [Header("Build View")]
        [SerializeField] private List<View> _buildsView;

        [SerializeField] private Shop _shop;    
        [SerializeField] private BuildingContext[] _buildingsContext;

        [Header("Save Data")]
        [SerializeField] private GameData _gameData;

        private DependencyContainer _container;

        private BinarySaveSystem _saveSystem;
        private CommandBuildFabric _buildFabric;
        private CommandInvoker _commandInvoker;
        private StateManager _stateManager;
        private BuildingStateFactory _buildingStateFactory;

        private void Awake()
        {
            _container = new DependencyContainer();

            _saveSystem = new BinarySaveSystem();
            _gameData =  CreateNewGameData();

            InitializeDependencies();
            Init();
        }

        private void InitializeDependencies()
        {
            _buildingStateFactory = new BuildingStateFactory();
            _commandInvoker = new CommandInvoker();
            _buildFabric = new CommandBuildFabric();
            _stateManager = new StateManager(_buildingStateFactory);
            
            _container.Register(_gameData);
            _container.Register(_gameData.BuildsData);
            _container.Register(_stateManager);
            _container.Register(_buildFabric);          
            _container.Register(_buildsView);
            _container.Register(_buildingStateFactory);
            _container.Register(_commandInvoker);
            _container.Register(_resourcesManager);

            _resourceView.Init();
            _resourcesManager.Init(_resourceView, _gameData.ResorcesData.ToResourceList());
            _buildFabric.Init(_container);

            _inputController.Init(_buildFabric);
            InitView();
        }


        private void InitView()
        {
           
            foreach (var item in _buildsView)
            {
                item.Init(_buildFabric);
            }
        }

        private void Init()
        {
            _cameraZooming.Init();
            _cameraMovement.Init();
            _shop.Init(_buildFabric, _gameData);

            for (int i = 0; i < _buildingsContext.Length; i++)
            {
                if (i >= _gameData.BuildsData.Length)
                {
                    Debug.LogError("Mismatch between GameData and BuildingContext");
                    continue;
                }

                _buildingsContext[i].Init(_container);

                if (!_gameData.BuildsData[i].Bought)
                    _buildingsContext[i].gameObject.SetActive(false);
            }
        }


        private void SaveGame()
        {
            //foreach (var building in _buildingsContext)
            //{
            //    if (building == null) continue;
            //    building.UpdateGameData(_gameData);
            //}
            _saveSystem.Save(_gameData);
        }

        private void OnApplicationPause(bool pause)
        {
            if (pause) SaveGame();
        }

        private void OnApplicationQuit()
        {
            SaveGame();
        }


        private void LoadGameData()
        {
            _gameData = _saveSystem.Load<GameData>() ?? CreateNewGameData();
        }

        private GameData CreateNewGameData()
        {
            Debug.Log("Creating new game data");
            return new GameData
            {
                ResorcesData = new GameResources 
                { 
                    Bonds = 10000, 
                    Coins = 10000,
                    Wood = 10000,
                    Ore = 10000,
                    Coal = 10000,
                    Oil = 10000                   
                },
                BuildsData = new BuildData[] { new BuildData { TimeBuilding = 200 } }
            };
        }


        public T ResolveDependency<T>()
        {
            return _container.Resolve<T>();
        }
    }
}
