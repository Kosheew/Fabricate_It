using UnityEngine;
using UnityEngine.UI;

public abstract class ResourceView : MonoBehaviour
{
    [SerializeField] private Text _resourceText;

    public virtual void UpdateResouce(int value)
    {
        _resourceText.text = $"{value}";
    }
}