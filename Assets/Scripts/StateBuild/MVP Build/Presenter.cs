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
        protected CommandInvoker _invoker;
        public Presenter(View view, BuildingContext context)
        {
            _view = view;
            _context = context;
            _invoker = new CommandInvoker();
        }

        public abstract void ButtonPressed();
    }

    public class ConstructionProgressPresenter : Presenter
    {
        public ConstructionProgressPresenter(View view, BuildingContext context) : base(view, context) { }

        public override void ButtonPressed()
        {
            ICommand speedUpCommand = new SpeedUpCommand(_context, 50000);
            _invoker.SetCommand(speedUpCommand);
            _invoker.ExecuteCommands();
        }
    }

    public class UpgradePresenter : Presenter
    {
        public UpgradePresenter(View view, BuildingContext context) : base(view, context) { }

        public override void ButtonPressed()
        {
            ICommand upgradeCommand = new UpgradeCommand(_context);
            _invoker.SetCommand(upgradeCommand);
            _invoker.ExecuteCommands();
        }
    }

    public class RestorePresenter : Presenter
    {
        public RestorePresenter(View view, BuildingContext context) : base(view, context) { }

        public override void ButtonPressed()
        {
            ICommand restoreCommand = new RepairCommand(_context);
            _invoker.SetCommand(restoreCommand);
            _invoker.ExecuteCommands();
        }
    }

}