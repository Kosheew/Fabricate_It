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

        private BinarySaveSystem _saveSystem;
        private CommandBuildFabric _buildFabric;
        private CommandInvoker _commandInvoker;
        private StateManager _stateManager;

        private void Awake()
        {
            _saveSystem = new BinarySaveSystem();   
            _gameData = _saveSystem.Load<GameData>();
            LoadGameData();

            _commandInvoker = new CommandInvoker();
            _buildFabric = new CommandBuildFabric();
            _stateManager = new StateManager();

            _resourceView.Init();
            _resourcesManager.Init(_resourceView, _gameData.ResorcesData.ToResourceList());
            _buildFabric.Init(_commandInvoker, _resourcesManager);

            _inputController.Init(_buildFabric);

            
            InitView();

            Init();
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

            for(int i = 0; i < _buildingsContext.Length; i++) 
            {
                _buildingsContext[i].Init(_gameData.BuildsData[i], _stateManager, _buildsView);

                if (!_gameData.BuildsData[i].Bought)
                    _buildingsContext[i].gameObject.SetActive(false);
            }
        }

        private void OnApplicationPause(bool pause)
        {
            Debug.Log("Save");
            _saveSystem.Save(_gameData);
        }

        private void OnApplicationQuit()
        {
            _saveSystem.Save(_gameData);
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
                ResorcesData = new GameResources { Bonds = 100, Coins = 100 },
                BuildsData = new List<BuildData> { new BuildData { TimeBuilding = 200 } }
            };
        }
    }
}
