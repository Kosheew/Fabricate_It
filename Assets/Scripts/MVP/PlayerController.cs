using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private View view;
    private PlayerModel model;
    private Presenter presenter;

    private void Start()
    {
        model = new PlayerModel(3);
        presenter = new Presenter(model, view);
        view.SetHealth(model.CurrentHealth);
    }

    public void TakeDamage(int damage)
    {
        model.TakeDamage(damage);
        view.UpdateHealth(model.CurrentHealth);
    }
}

