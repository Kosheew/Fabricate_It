using UnityEngine;
using UnityEngine.UI;
using PresenterBuildings;

namespace ViewBuildings
{
    public class RepairBuildingView : View
    {
        [SerializeField] private Button _repairButton;
        [SerializeField] private Button _buttonMove;

        public override void Init(DependencyContainer container)
        {
            var commandBuild = container.Resolve<CommandBuildFabric>();
            _presenter = new RepairPresenter(this, commandBuild);
            _repairButton.onClick.AddListener(() => _presenter.ButtonPressed1());
            _buttonMove.onClick.AddListener(() => _presenter.ButtonPressed2());
        }
    }
}
