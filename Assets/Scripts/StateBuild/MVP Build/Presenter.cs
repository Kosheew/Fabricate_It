using Buildings;
using Command.Build;
using Command;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ViewBuildings;

namespace PresenterBuildings
{
    public abstract class Presenter
    {
        protected View _view;
        protected BuildingContext _context;
        public Presenter(View view, BuildingContext context)
        {
            _view = view;
            _context = context;
        }
    }

    public class ConstructionProgressPresenter : Presenter
    {
        public ConstructionProgressPresenter(View view, BuildingContext context) : base(view, context) { }

        public void OnSpeedUpButtonPressed()
        {
            ICommand speedUpCommand = new SpeedUpCommand(_context, 50000);
            CommandInvoker invoker = new CommandInvoker();
            invoker.SetCommand(speedUpCommand);
            invoker.ExecuteCommands();
        }
    }

    public class UpgradePresenter : Presenter
    {
        public UpgradePresenter(View view, BuildingContext context) : base(view, context) { }

        public void OnUpgradeButtonPressed()
        {
            ICommand upgradeCommand = new UpgradeCommand(_context);
            CommandInvoker invoker = new CommandInvoker();
            invoker.SetCommand(upgradeCommand);
            invoker.ExecuteCommands();
        }
    }

    public class RestorePresenter : Presenter
    {
        public RestorePresenter(View view, BuildingContext context) : base(view, context) { }

        public void OnRestoreButtonPressed()
        {
            //ICommand restoreCommand = new RestoreCommand(_context);
            //CommandInvoker invoker = new CommandInvoker();
            //invoker.SetCommand(restoreCommand);
            //invoker.ExecuteCommands();
        }
    }

}