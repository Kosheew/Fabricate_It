using UnityEngine;
using UnityEngine.UI;
using PresenterBuildings;

namespace ViewBuildings
{
    public class StateBuildingView : View
    {
        [SerializeField] private Button _upgradeButton;
        [SerializeField] private Button _buttonMove;

        public override void Init(CommandBuildFabric commandBuild)
        {
            _presenter = new UpgradePresenter(this, commandBuild);
            _upgradeButton.onClick.AddListener(() => _presenter.ButtonPressed1());
            _buttonMove.onClick.AddListener(() => _presenter.ButtonPressed2());
        }
    }
}
