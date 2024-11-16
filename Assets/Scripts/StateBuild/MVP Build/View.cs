using UnityEngine;
using PresenterBuildings;

namespace ViewBuildings
{
    public abstract class View : MonoBehaviour
    {
        [SerializeField] private GameObject _statePanel;

        protected Presenter _presenter;

        public abstract void Init(DependencyContainer container);

        public void ShowStatePanel()
        {
            _statePanel.SetActive(!_statePanel.activeSelf);
        }

        public void HideStatePanel()
        {
            _statePanel.SetActive(false);
        }
    }
}