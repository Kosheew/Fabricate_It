using UnityEngine;
namespace Dilemmas
{
    [CreateAssetMenu(fileName = "Dilemma", menuName = "ScriptableObjects/Dilemma", order = 1)]
    public class DilemmaSO : ScriptableObject
    {
        [SerializeField] private string title;
        [SerializeField] private string[] options;
        [SerializeField] private string[] reward;
        [SerializeField] private string[] consequences;

        [Range(-200, 200)]
        [SerializeField] private int[] outputs;

        public string Title => title;
        public string[] Options => options;
        public string[] Reward => reward;
        public string[] Consequences => consequences;
        public int[] Outputs => outputs;
    }
}
