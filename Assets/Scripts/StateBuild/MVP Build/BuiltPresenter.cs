using Buildings;
using BuildingState;
using Command;
using Command.Build;

public class BuiltPresenter
{
    private BuildView _view;
    private BuildingContext _context;

    public BuiltPresenter(BuildView view, BuildingContext context)
    {
        _view = view;
        _context = context;
    }

    public void OnUpgradeButtonPressed()
    {
        ICommand upgradeCommand = new UpgradeCommand(_context);
        CommandInvoker invoker = new CommandInvoker();
        invoker.SetCommand(upgradeCommand);
        invoker.ExecuteCommands();
    }
}
