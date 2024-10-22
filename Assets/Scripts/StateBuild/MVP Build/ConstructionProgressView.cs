using UnityEngine;
using UnityEngine.UI;
using PresenterBuildings;
using Buildings;

namespace ViewBuildings
{
    public class ConstructionProgressView : View
    {
        [SerializeField] private GameObject _progressPanel;
        [SerializeField] private Text _timeText;
        [SerializeField] private Slider _progressSlider;
        [SerializeField] private Button speedUpButton;
        
        private float _progressValue;

        public override void Init()
        {
            _presenter = new ConstructionProgressPresenter(this, GetComponent<BuildingContext>());
            speedUpButton.onClick.AddListener(() => _presenter.ButtonPressed());
        }

        public void SetTimeBuilding(float timeBuilding)
        {
            _progressValue = timeBuilding;
            _progressSlider.maxValue = timeBuilding;
            _progressSlider.value = 0;
        }

        public void UpdateProgress(float timeBuilding)
        {
            float minutes = Mathf.FloorToInt(timeBuilding / 60);
            float seconds = Mathf.FloorToInt(timeBuilding % 60);

            _timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            _progressSlider.value = timeBuilding;
        }

        public void EndBuilding()
        {
            _progressPanel.SetActive(false);
        }
    }
}
