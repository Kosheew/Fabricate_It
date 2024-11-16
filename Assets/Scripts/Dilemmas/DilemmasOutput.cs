using System.Reflection;
using UnityEngine;

namespace Dilemmas
{
    public class DilemmasOutput : MonoBehaviour
    {
        private GameResources _resources;
        private ResourcesManager _resourcesManager;
        public void Init(GameResources resources, ResourcesManager resourcesManager)
        {
            _resources = resources;
            _resourcesManager = resourcesManager;
        }
        public void GetOutput(DilemmaOutputParametersSO parameters)
        {
            string recType = $"{parameters.ResourcesOptions}";
            FieldInfo field = typeof(GameResources).GetField(recType);
            int value = (int)field.GetValue(_resources);
            int updatedValue = value + parameters.Dilemma.Reward[parameters.RewardIndex];
            field.SetValue(_resources, updatedValue);

            _resourcesManager.ChangeReputation(parameters.Dilemma.Outputs[parameters.OutputIndex]);
        }
    }
}
