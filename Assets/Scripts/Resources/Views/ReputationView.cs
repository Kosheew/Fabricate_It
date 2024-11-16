using UnityEngine;
using UnityEngine.UI;

public class ReputationView : ResourceView
{
    [SerializeField] private Slider _scale;

    private void Start()
    {
        _scale.maxValue = 100f;
        _scale.minValue = -100f;
    }

    public override void UpdateResouce(int value)
    {
        _scale.value = value;
    }
}
