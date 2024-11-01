/// <summary>
/// Інтерфейс для команд, що керують станом будівництва.
/// </summary>
/// 

namespace CommandBuild
{
    public abstract class Command
    {
       public abstract void Execute();
    }
}