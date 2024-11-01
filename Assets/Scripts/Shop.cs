using Buildings;
using UnityEngine;
using CommandBuild.Build;
using CommandBuild;

public class Shop : MonoBehaviour
{
    [SerializeField] private BuildingContext _capitoliy;

    private CommandInvoker _invoker;

    private Command _plainningBuilCommand;



    private void Start()
    {
        _invoker = new CommandInvoker();

        _plainningBuilCommand = new PlanningBuildCommand(_capitoliy);

    }



    public void ChooseBuild()
    {
        _invoker.SetCommand(_plainningBuilCommand);
        _invoker.ExecuteCommands();
    }

   
}
