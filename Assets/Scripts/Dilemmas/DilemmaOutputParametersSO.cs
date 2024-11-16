using UnityEngine;

namespace Dilemmas
{
    [CreateAssetMenu(fileName = "DilemmaOutput", menuName = "ScriptableObjects/DilemmaOutput", order = 1)]
    public class DilemmaOutputParametersSO : ScriptableObject
    {
        public DilemmaSO Dilemma;
        public int OutputIndex;
        public int RewardIndex;
        public ResourcesOptions ResourcesOptions;
    }

    public enum ResourcesOptions
    {
        Bonds, Coins, Oil, Coal, Ore, Wood
    }
}
