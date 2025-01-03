using PresenterBuildings;
using UnityEngine.UI;
using UnityEngine;

namespace ViewBuildings
{
    public class SpeedUpView : View
    {
        [SerializeField] private Button _speedUpButton;
        [SerializeField] private Button _buttonMove;

        public override void Init(DependencyContainer container)
        {
            var commandBuild = container.Resolve<CommandBuildFabric>();
            _presenter = new SpeedUpPresenter(this, commandBuild);
            _speedUpButton.onClick.AddListener(() => _presenter.ButtonPressed1());
            _buttonMove.onClick.AddListener(() => _presenter.ButtonPressed2());
        }
    }
}