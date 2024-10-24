using UnityEngine;
public class SceneInvoker
{
    private Command command;

    public void SetCommand(Command command)
    {
        this.command = command;
    }
    public void ExecuteCommand()
    {
        command?.Execute();
    }
}
