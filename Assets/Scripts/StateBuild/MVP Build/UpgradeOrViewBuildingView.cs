using UnityEngine;
using UnityEngine.UI;
using PresenterBuildings;
using Buildings;

namespace ViewBuildings
{
    public class UpgradeOrViewBuildingView : View
    {
        [SerializeField] private Button upgradeButton;
        [SerializeField] private Button moveButton;

        public override void Init()
        {
            _presenter = new UpgradePresenter(this, GetComponent<BuildingContext>());
            upgradeButton.onClick.AddListener(() => _presenter.ButtonPressed());
            moveButton.onClick.AddListener(() => _presenter.ButtonMove());
        }
    }
}
