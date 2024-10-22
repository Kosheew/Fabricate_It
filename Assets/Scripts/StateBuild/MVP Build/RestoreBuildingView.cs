using UnityEngine;
using UnityEngine.UI;
using PresenterBuildings;
using Buildings;

namespace ViewBuildings
{
    public class RestoreBuildingView : View
    {
        [SerializeField] private Button restoreButton;

        public override void Init()
        {
            _presenter = new RestorePresenter(this, GetComponent<BuildingContext>());
            restoreButton.onClick.AddListener(() => _presenter.ButtonPressed());
        }
    }
}
