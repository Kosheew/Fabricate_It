using UnityEngine;

namespace Dilemmas
{
    public class DilemmasOutput : MonoBehaviour
    {
        [SerializeField] private GameObject _dilemmaPanel;
        private ResourcesManager _resourcesManager;
        public void Init(ResourcesManager resourcesManager)
        {
            _resourcesManager = resourcesManager;
        }
        public void GetOutput(DilemmaOutputParametersSO parameters)
        {
            _resourcesManager.AddResource(parameters.ResourceType, parameters.Reward);
            _resourcesManager.AddResource(ResourceType.Reputation, parameters.Dilemma.Outputs[parameters.OutputIndex]);
            _dilemmaPanel.SetActive(false);
        }
    }
}
