using UnityEngine;
using Buildings;
using BuildingState;
/// <summary>
/// ������� ��� ����������� ���������� �� ��������� ��������.
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
            // ����� ��� ����������� ����������
            if (_context.CurrentState is UnderConstructionState)
            {
                Debug.Log("Speeding up construction.");
                // ���������, ��������� ��� ���������� ������� �� ������� ��������
                float reduction = _crystals * 10f; // 10 ������ �� ����� �������
                _context.ReduceBuildTime(reduction);
            }
            else
            {
                Debug.Log("Building cannot be sped up in the current state.");
            }
        }
    }
}