public class Presenter
{
    protected PlayerModel playerModel;
    protected View view;

    public Presenter(PlayerModel playerModel, View view)
    {
        this.playerModel = playerModel;
        this.view = view;
        view.Init(this);
    }

    public void OnViewInitialized()
    {
        view.SetHealth(playerModel.CurrentHealth);
    }

    public void OnDisplayHealth()
    {
        playerModel.TakeDamage(1);
        view.UpdateHealth(playerModel.CurrentHealth);
    }

}

