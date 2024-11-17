using UnityEngine;
namespace Dilemmas
{
    [CreateAssetMenu(fileName = "Dilemma", menuName = "ScriptableObjects/Dilemma", order = 1)]
    public class DilemmaSO : ScriptableObject
    {
        [Header("Dilemma parameters")]
        [SerializeField] private string title;
        [SerializeField] private string[] options;
        [SerializeField] private string[] reward;
        [SerializeField] private string[] consequences;

        [Range(-200, 200)]
        [SerializeField] private int[] reputationOutputs;

        [Header("Dialog")]
        [SerializeField] private string person1;
        [SerializeField] private string person2;

        [SerializeField] private Sprite person1Photo;
        [SerializeField] private Sprite person2Photo;

        [SerializeField] private string[] phrases;

        public string Title => title;
        public string[] Options => options;
        public string[] Reward => reward;
        public string[] Consequences => consequences;
        public int[] ReputationOutputs => reputationOutputs;

        public string Person1 => person1;
        public string Person2 => person2;
        public Sprite Person1Photo => person1Photo;
        public Sprite Person2Photo => person2Photo;
        public string[] Phrases => phrases;
    }
}
