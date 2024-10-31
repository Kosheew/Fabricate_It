using UnityEngine;
using PresenterBuildings;
using UnityEngine.UI;

namespace ViewBuildings
{
    public abstract class View : MonoBehaviour
    {
        [SerializeField] private GameObject _statePanel;
        [SerializeField] protected Button _buttonMove;

        protected Presenter _presenter;

        public abstract void Init();

        public void ShowStatePanel()
        {
            _statePanel.SetActive(true);
        }
    }
}