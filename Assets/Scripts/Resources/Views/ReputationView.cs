using UnityEngine;
using UnityEngine.UI;

public class ReputationView : MonoBehaviour
{
    [SerializeField] private Slider _scale;

    private void Start()
    {
        _scale.maxValue = 100f;
        _scale.minValue = -100f;
    }

    public void UpdateResource(int value)
    {
        _scale.value = value;
    }
}
