using UnityEngine;
using Buildings;
using BuildingState;
using System;
/// <summary>
/// Команда для прискорення будівництва за допомогою кристалів.
/// </summary>
namespace CommandBuild.Build
{
    public class SpeedUpCommand : Command
    {
        private BuildingContext _context;
        private GameResources _resources;

        public SpeedUpCommand(BuildingContext context, GameResources resources)
        {
            _context = context;
            _resources = resources;
        }

        public override void Execute()
        {
            // Логіка для прискорення будівництва
            if (_context.CurrentState is UnderConstructionState)
            {
                DateTime currentTime = DateTime.Now;
                DateTime endTime = _context.EndTimeBuilding;


                float remainingTime = (float)(endTime - currentTime).TotalSeconds;
                Debug.Log(remainingTime);

                if ((int)remainingTime <= _resources.Bonds)
                {
                    _resources.Bonds -= (int)remainingTime;

                    Debug.Log(_resources.Bonds);

                    _context.ShowPanel();
                    _context.TransitionToState(_context.BuiltState);
                }

            }
            else
            {
                Debug.Log("Building cannot be sped up in the current state.");
            }
        }
    }
}