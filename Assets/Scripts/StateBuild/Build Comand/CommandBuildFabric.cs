using Buildings;
using CommandBuild.Build;
using Managers;

public class CommandBuildFabric
{
    private CommandInvoker _commandInvoker;

    private BuildingContext _buildingContext;

    private ResourcesManager _resourcesManager;

    private DependencyContainer _dependencyContainer;

    public void Init(DependencyContainer container)
    {
        _dependencyContainer = container;
        _commandInvoker = container.Resolve<CommandInvoker>();
        _resourcesManager = container.Resolve<ResourcesManager>();
    }

    public void SetBuild(BuildingContext context)
    {
        _buildingContext = context;
    }

    public void CreateBuildBuyCommand()
    {
        Command buildBuyCommand = new BuildBuy(_buildingContext, _dependencyContainer);
        _commandInvoker.SetCommand(buildBuyCommand);
        _commandInvoker.ExecuteCommands();
    }

    public void CreateStartPlacmentCommand()
    {
        Command placmentBuildCommand = new StartPlacmentCommand(_buildingContext, _dependencyContainer);
        _commandInvoker.SetCommand(placmentBuildCommand);
        _commandInvoker.ExecuteCommands();
    }

    public void CreateSpeedUpCommand()
    {
        Command speedUpCommand = new SpeedUpCommand(_buildingContext, _resourcesManager);
        _commandInvoker.SetCommand(speedUpCommand);
        _commandInvoker.ExecuteCommands();
    }

    public void CreateUpgradeCommand()
    {
        Command upgradeCommand = new UpgradeCommand(_buildingContext, _resourcesManager);
        _commandInvoker.SetCommand(upgradeCommand);
        _commandInvoker.ExecuteCommands();
    }

    public void CreateRepairCommand()
    {
        Command restoreCommand = new RepairCommand(_buildingContext);
        _commandInvoker.SetCommand(restoreCommand);
        _commandInvoker.ExecuteCommands();
    }

    public void CreateEndPlacmentCommand()
    {
        Command moveCommand = new EndPlacmentCommand(_buildingContext);
        _commandInvoker.SetCommand(moveCommand);
        _commandInvoker.ExecuteCommands();
    }

    public void CreateRefuceBuildCommand()
    {
        Command moveCommand = new RefuceBuildBuy(_buildingContext, _dependencyContainer);
        _commandInvoker.SetCommand(moveCommand);
        _commandInvoker.ExecuteCommands();
    }

    public void CreatePlanningBuildCommand(BuildingContext buildingContext)
    {
        Command planningCommand = new PlanningBuildCommand(buildingContext, _dependencyContainer);
        _commandInvoker.SetCommand(planningCommand);
        _commandInvoker.ExecuteCommands();
    }

}
