using UnityEngine;
using Buildings;
using BuildingState;
using System;
/// <summary>
/// ������� ��� ����������� ���������� �� ��������� ��������.
/// </summary>
namespace CommandBuild.Build
{
    public class SpeedUpCommand : Command
    {
        private BuildingContext _context;
        private ResourcesManager _resources;

        public SpeedUpCommand(BuildingContext context, ResourcesManager resources)
        {
            _context = context;
            _resources = resources;
        }

        public override void Execute()
        {
        //    if (_context.CurrentState is UnderConstructionState)
        //    {
        //        DateTime currentTime = DateTime.Now;
        //        DateTime endTime = _context.EndTimeBuilding;


        //        float remainingTime = (float)(endTime - currentTime).TotalSeconds;
        //        Debug.Log(remainingTime);
        //        if (_resources.HasEnoughResource(ResourceType.Bond, (int)remainingTime))
        //        {
        //            _resources.SubtractResource(ResourceType.Bond, (int)remainingTime);

        //            _context.ShowPanel();
        //        //    _context.TransitionToState(_context.BuiltState);
        //        }

        //    }
        //    else
        //    {
        //        Debug.Log("Building cannot be sped up in the current state.");
        //    }
        }
    }
}