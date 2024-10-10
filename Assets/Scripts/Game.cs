using Game.CameraControllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Game : MonoBehaviour
    {
        private BinarySaveSystem _saveSystem;
        [SerializeField] private CameraZooming _cameraZooming;
        [SerializeField] private CameraMovement _cameraMovement;

        [SerializeField] private GameView _gameView;

        [SerializeField] private BuildingContext _buildingContext;

        [Header("Save Data")]
        public GameData _gameData;

        private void Awake()
        {
            _saveSystem = new BinarySaveSystem();   
            _gameData = _saveSystem.Load<GameData>();

            if (_gameData == null)
            {
                Debug.Log("Load");
                _gameData = new GameData()
                {
                    CurrencyData = new Currency()
                    {
                        Bonds = 100,
                        Coins = 100,
                    },
                    BuildsData = new List<BuildData>()
                    {
                        new BuildData()
                        {
                            TimeBuilding = 200
                        }
                    }
                };
            }



            _gameView.UpdateCoins(_gameData.CurrencyData.Coins);
            _gameView.UpdateBonds(_gameData.CurrencyData.Bonds);
            
            Init();
        }

        private void Init()
        {
            _cameraZooming.Init();
            _cameraMovement.Init();
            _buildingContext.Init(_gameData.BuildsData[0]);
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

    }
}
