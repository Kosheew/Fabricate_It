using UnityEngine;
using Buildings;
using BuildingState;
/// <summary>
/// Команда для прискорення будівництва за допомогою кристалів.
/// </summary>
namespace CommandBuild.Build
{
    public class SpeedUpCommand : Command
    {
        private BuildingContext _context;
        private int _crystals;

        public SpeedUpCommand(BuildingContext context, int crystals)
        {
            _context = context;
            _crystals = crystals;
        }

        public override void Execute()
        {
            // Логіка для прискорення будівництва
            if (_context.CurrentState is UnderConstructionState)
            {
                Debug.Log("Speeding up construction.");
                // Наприклад, скорочуємо час будівництва залежно від кількості кристалів
                float reduction = _crystals * 10f; // 10 секунд на кожен кристал
                _context.ReduceBuildTime(reduction);
            }
            else
            {
                Debug.Log("Building cannot be sped up in the current state.");
            }
        }
    }
}