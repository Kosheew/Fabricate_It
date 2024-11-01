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
        [SerializeField] private View UpgradeOrViewBuildingView;
        [SerializeField] private View RestoreBuildingView;
        [SerializeField] private View MoveBuildView;
        [SerializeField] private View PlainningBuildView;


        [SerializeField] private BuildingContext _buildingContext;

        [Header("Save Data")]
        public GameData _gameData;

        private CommandBuildFabric _buildFabric;

        [SerializeField] InputController _inputController;

        private void Awake()
        {
            _saveSystem = new BinarySaveSystem();   
            _gameData = _saveSystem.Load<GameData>();
            _buildFabric = new CommandBuildFabric();

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

            UpgradeOrViewBuildingView.Init(_buildFabric);
            RestoreBuildingView.Init(_buildFabric);
            MoveBuildView.Init(_buildFabric);
            PlainningBuildView.Init(_buildFabric);
        }


        private void Init()
        {
            _cameraZooming.Init();
            _cameraMovement.Init();
            _buildingContext.Init(_gameData.BuildsData[0], _buildFabric);
            _buildingContext.gameObject.SetActive(false);
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
