using UnityEngine;
using UnityEngine.UI;
using PresenterBuildings;
using Buildings;

namespace ViewBuildings
{
    public class MoveBuildView : View
    {   
        public override void Init()
        {
            _presenter = new MovePresenter(this, GetComponent<BuildingContext>());
            _buttonMove.onClick.AddListener(() => _presenter.ButtonPressed());
        }
    }
}