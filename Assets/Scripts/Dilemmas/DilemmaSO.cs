using UnityEngine;
namespace Dilemmas
{
    [CreateAssetMenu(fileName = "Dilemma", menuName = "ScriptableObjects/Dilemma", order = 1)]
    public class DilemmaSO : ScriptableObject
    {
        public string Title;
        public string[] Options;
        public int[] Reward;
        public string[] Consequences;

        [Range(-200, 200)]
        public int[] Outputs;
    }
}
