using System.Collections.Generic;

/// <summary>
/// ����, ���� ������� �� ������ ������.
/// </summary>


public class CommandInvoker
{
    private List<Command> _commands = new List<Command>();

    public void SetCommand(Command command)
    {
        _commands.Add(command);
    }

    public void ExecuteCommands()
    {
        foreach (var command in _commands)
        {
            command.Execute();
        }
        _commands.Clear();
    }
}