using UnityEngine;

namespace Dilemmas
{
    [CreateAssetMenu(fileName = "DilemmaOutput", menuName = "ScriptableObjects/DilemmaOutput", order = 1)]
    public class DilemmaOutputParametersSO : ScriptableObject
    {
        public DilemmaSO Dilemma;
        public int OutputIndex;
        public int Reward;
        public ResourceType ResourceType;
    }
}
