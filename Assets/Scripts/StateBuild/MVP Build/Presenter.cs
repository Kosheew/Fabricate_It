using Buildings;
using CommandBuild.Build;
using CommandBuild;
using UnityEngine;
using ViewBuildings;

namespace PresenterBuildings
{
    public abstract class Presenter
    {
        protected View _view;
        protected CommandBuildFabric _commandFabric;
        public Presenter(View view, CommandBuildFabric commandFabric)
        {
            _view = view;
            _commandFabric = commandFabric;
        }

        public abstract void ButtonPressed1();
        public abstract void ButtonPressed2();
       
    }

    public class SpeedUpPresenter : Presenter
    {
        public SpeedUpPresenter(View view, CommandBuildFabric commandFabric) : base(view, commandFabric) { }
        public override void ButtonPressed1() => _commandFabric.CreateSpeedUpCommand();       
        public override void ButtonPressed2() => _commandFabric.CreateStartPlacmentCommand();
    }

    public class UpgradePresenter : Presenter
    {
        public UpgradePresenter(View view, CommandBuildFabric commandFabric) : base(view, commandFabric) { }
        public override void ButtonPressed1() => _commandFabric.CreateUpgradeCommand();
        public override void ButtonPressed2() => _commandFabric.CreateStartPlacmentCommand();
    }

    public class RepairPresenter : Presenter
    {
        public RepairPresenter(View view, CommandBuildFabric commandFabric) : base(view, commandFabric) { }

        public override void ButtonPressed1() => _commandFabric.CreateRepairCommand();

        public override void ButtonPressed2() => _commandFabric.CreateStartPlacmentCommand();
    }

    public class MovePresenter : Presenter
    {
        public MovePresenter(View view, CommandBuildFabric commandFabric) : base(view, commandFabric) { }
        public override void ButtonPressed1() => _commandFabric.CreateEndPlacmentCommand();

        public override void ButtonPressed2()
        {

        }
    }

    public class PlanningPresenter : Presenter
    {
        public PlanningPresenter(View view, CommandBuildFabric commandFabric) : base(view, commandFabric) { }
        public override void ButtonPressed1() => _commandFabric.CreateRefuceBuildCommand();

        public override void ButtonPressed2() => _commandFabric.CreateBuildBuyCommand();
    }
}