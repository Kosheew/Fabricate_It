using PresenterBuildings;
using Buildings;
using UnityEngine;
using UnityEngine.UI;

namespace ViewBuildings
{
    public class PlanningBuildView : View 
    {
        [SerializeField] private Button _refuceButton;
        [SerializeField] private Button _buyButton;
        public override void Init(DependencyContainer container)
        {
            var commandBuild = container.Resolve<CommandBuildFabric>();
            _presenter = new PlanningPresenter(this, commandBuild);
            _refuceButton.onClick.AddListener(() => _presenter.ButtonPressed1());
            _buyButton.onClick.AddListener(() => _presenter.ButtonPressed2());
        }
    }
}
