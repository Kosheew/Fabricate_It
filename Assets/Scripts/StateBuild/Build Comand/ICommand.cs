/// <summary>
/// Інтерфейс для команд, що керують станом будівництва.
/// </summary>
/// 

namespace Command
{
    public interface ICommand
    {
        void Execute();
    }
}