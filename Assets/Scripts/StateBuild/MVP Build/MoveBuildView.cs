using PresenterBuildings;
using UnityEngine;
using UnityEngine.UI;

namespace ViewBuildings
{
    public class MoveBuildView : View
    {
        [SerializeField] private Button _buttonEndMove;
        public override void Init(DependencyContainer container)
        {
            var commandBuild = container.Resolve<CommandBuildFabric>();
            _presenter = new MovePresenter(this, commandBuild);
            _buttonEndMove.onClick.AddListener(() => _presenter.ButtonPressed1());
        }
    }
}