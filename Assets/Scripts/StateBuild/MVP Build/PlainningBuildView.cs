using PresenterBuildings;
using Buildings;
using UnityEngine;
using UnityEngine.UI;

namespace ViewBuildings
{
    public class PlainningBuildView : View 
    {
        [SerializeField] private Button _refuceButton;
        [SerializeField] private Button _buyButton;
        public override void Init(CommandBuildFabric commandBuild)
        {
            _presenter = new PlanningPresenter(this, commandBuild);
            _refuceButton.onClick.AddListener(() => _presenter.ButtonPressed1());
            _buyButton.onClick.AddListener(() => _presenter.ButtonPressed2());
        }
    }
}
