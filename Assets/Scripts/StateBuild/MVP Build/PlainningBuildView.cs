using PresenterBuildings;
using Buildings;
using UnityEngine;
using UnityEngine.UI;

namespace ViewBuildings
{
    public class PlainningBuildView : View 
    {
        [SerializeField] private Button _refuceButton;
        public override void Init()
        {
            _presenter = new PlainningPresenter(this, GetComponent<BuildingContext>());
            _refuceButton.onClick.AddListener(() => _presenter.ButtonPressed());
            _buttonMove.onClick.AddListener(() => _presenter.PlainningButton());
        }
    }
}
