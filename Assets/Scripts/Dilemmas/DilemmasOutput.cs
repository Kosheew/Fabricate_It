using UnityEngine;

namespace Dilemmas
{
    public class DilemmasOutput : MonoBehaviour
    {
        [SerializeField] private GameObject _dilemmaPanel;

        private ResourcesManager _resourcesManager;
        public void Init(DependencyContainer container)
        {
            _resourcesManager = container.Resolve<ResourcesManager>();
        }
        public void GetOutput(DilemmaOutputParametersSO parameters)
        {
            _resourcesManager.AddResource(parameters.ResourceType, parameters.Reward);
            _resourcesManager.AddResource(ResourceType.Reputation, parameters.Dilemma.ReputationOutputs[parameters.ReputationOutputIndex]);
            _dilemmaPanel.SetActive(false);
        }
    }
}
