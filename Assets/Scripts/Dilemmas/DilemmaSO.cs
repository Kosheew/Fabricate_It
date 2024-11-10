using UnityEngine;
[CreateAssetMenu(fileName = "Dilemma", menuName = "ScriptableObjects/Dilemma", order = 1)]
public class DilemmaSO : ScriptableObject
{
    public string Title;
    public string[] Options;
    public string[] Reward;
    public string[] Consequences;
    public float[] Outputs;
}
