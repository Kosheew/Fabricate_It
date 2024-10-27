using Buildings;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Command.Build;
using Command;

public class Shop : MonoBehaviour
{
    [SerializeField] private BuildingContext _capitoliy;

    void Start()
    {
        
    }

    public void BuyBuild()
    {
        ICommand buyCommand = new BuildBuy(_capitoliy);
        CommandInvoker invoker = new CommandInvoker();
        invoker.SetCommand(buyCommand);
        invoker.ExecuteCommands();
    }
}
