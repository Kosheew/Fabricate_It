using Game.CameraControllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Buildings;
using ViewBuildings;

namespace Game
{
    public class Game : MonoBehaviour
    {
        private BinarySaveSystem _saveSystem;
        [SerializeField] private CameraZooming _cameraZooming;
        [SerializeField] private CameraMovement _cameraMovement;

        [Header("Resource View")]
        [SerializeField] private ResourceView _coinsView;
        [SerializeField] private ResourceView _bondsView;
        [SerializeField] private ResourceView _oreView;
        [SerializeField] private ResourceView _coalView;
        [SerializeField] private ResourceView _woodView;

        [Header("Build View")]
        [SerializeField] private View StateBuildingView;
        [SerializeField] private View RepairBuildingView;
        [SerializeField] private View MoveBuildView;
        [SerializeField] private View PlainningBuildView;
        [SerializeField] private View SpeedUpView;

        [SerializeField] private Shop _shop;
        [SerializeField] private InputController _inputController;

        [SerializeField] private BuildingContext[] _buildingsContext;

        [Header("Save Data")]
        public GameData _gameData;

        private CommandBuildFabric _buildFabric;

        private void Awake()
        {
            _saveSystem = new BinarySaveSystem();   
            _gameData = _saveSystem.Load<GameData>();

            _buildFabric = new CommandBuildFabric();
            _buildFabric.Init();

            _inputController.Init(_buildFabric);

            LoadGameData();
            
            InitView();

            Init();
        }

        private void InitView()
        {
            _bondsView.UpdateResouce(_gameData.CurrencyData.Bonds);
            _coinsView.UpdateResouce(_gameData.CurrencyData.Coins);
            _oreView.UpdateResouce(_gameData.ResurcesData.Ore);
            _coalView.UpdateResouce(_gameData.ResurcesData.Coal);
            _woodView.UpdateResouce(_gameData.ResurcesData.Wood);

            StateBuildingView.Init(_buildFabric);
            RepairBuildingView.Init(_buildFabric);
            MoveBuildView.Init(_buildFabric);
            PlainningBuildView.Init(_buildFabric);
            SpeedUpView.Init(_buildFabric);
        }

        private void Init()
        {
            _cameraZooming.Init();
            _cameraMovement.Init();

            _shop.Init(_buildFabric);

            for(int i = 0; i < _buildingsContext.Length; i++) 
            {
                _buildingsContext[i].Init(_gameData.BuildsData[i], _buildFabric);

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
                CurrencyData = new Currency { Bonds = 100, Coins = 100 },
                BuildsData = new List<BuildData> { new BuildData { TimeBuilding = 200 } }
            };
        }
    }
}
