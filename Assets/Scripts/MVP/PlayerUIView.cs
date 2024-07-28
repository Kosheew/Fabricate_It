using UnityEngine;
using UnityEngine.UI;

public class PlayerUIView : View
{
    [SerializeField] private Button _button;
    [SerializeField] private Slider healthSlider;

    private void Start()
    {
        _button.onClick.AddListener(() =>
        {
            _presenter.OnDisplayHealth();
        });
    }
    public override void SetHealth(int health)
    {
        healthSlider.maxValue = health;
        healthSlider.value = health; 
    }

    public override void UpdateHealth(int health)
    {
        healthSlider.value = health;
    }
}

