using UnityEngine;
using PresenterBuildings;

namespace ViewBuildings
{
    public abstract class View : MonoBehaviour
    {
        [SerializeField] private GameObject _statePanel;
        
        protected Presenter _presenter;

        public abstract void Init();

        public void ShowStatePanel()
        {
            _statePanel.SetActive(true);
        }
    }
}